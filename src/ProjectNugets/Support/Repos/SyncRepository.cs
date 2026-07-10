using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System;

//using System.Runtime.Intrinsics.X86;
using System.Security.Policy;
using System.Reflection;
using System.Text;
using ProjectNugets.Support.Dtos;
using System.Drawing;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Configuration;

namespace ProjectNugets.Support.Repos
{
    internal static class SyncRepository
    {
        public static int toplength = 1;

        public static string nuget = "NugetsMain";
        public static string project = "ProjectsMain";
        public static string solution = "SolutionsMain";

        private static string dbConnectionString = "";

        public static string dbSqlConnectionString
        {
            get
            {
                var tmpconnectionString = ConfigurationManager.AppSettings["NugetDBConn"];
                if (dbConnectionString != tmpconnectionString)
                {
                    dbConnectionString = tmpconnectionString;
                }

                return dbConnectionString;
            }
            set { dbConnectionString = value; }
        }
        #region Main
        internal static void createNugetsTable()
        {
            try
            {
                using (var con = new SqlConnection(dbSqlConnectionString))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand(@"
		                    IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ApplicationNugets].[" + nuget + @"]') 
                                    AND type in (N'U'))
                                DROP TABLE [ApplicationNugets].[" + nuget + @"];

                            SET ANSI_NULLS ON;

                            SET QUOTED_IDENTIFIER ON;

                            CREATE TABLE [ApplicationNugets].[" + nuget + @"](
	                            [Id] [int] IDENTITY(1,1) NOT NULL,
	                            [projectId] [int] NOT NULL,
	                            [nugetName] [varchar](255) NOT NULL,
	                            [nugetPath] [varchar](1024) NOT NULL,
	                            [nugetVersion] [varchar](50) NULL,
                                [createdate] [DATETIME] NULL,
                             CONSTRAINT [PK_" + nuget + @"] PRIMARY KEY CLUSTERED 
                            (
	                            [Id] ASC
                            )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, 
                                ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
                            ) ON [PRIMARY];", con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandTimeout = 30;
                        var iId = cmd.ExecuteNonQuery();
                    }

                }
            }
            catch { }
        }

        internal static void createProjectsTable()
        {
            try
            {
                using (var con = new SqlConnection(dbSqlConnectionString))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand(@"
                        IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ApplicationNugets].[" + project + @"]') AND type in (N'U'))
                            DROP TABLE [ApplicationNugets].[" + project + @"];

                        SET ANSI_NULLS ON;

                        SET QUOTED_IDENTIFIER ON;

                        CREATE TABLE [ApplicationNugets].[" + project + @"](
	                        [Id] [int] IDENTITY(1,1) NOT NULL,
	                        [solutionId] [int] NOT NULL,
	                        [projectName] [varchar](255) NOT NULL,
	                        [projectPath] [varchar](1024) NOT NULL,
	                        [netVersion] [varchar](50) NULL,
	                        [isNuget] [bit] NOT NULL,
                            [createdate] [DATETIME] NULL,
                         CONSTRAINT [PK_" + project + @"] PRIMARY KEY CLUSTERED 
                        (
	                        [Id] ASC
                        )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
                        ) ON [PRIMARY];", con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandTimeout = 30;
                        var iId = cmd.ExecuteNonQuery();
                    }

                }
            }
            catch { }
        }

        internal static void createSolutionsTable()
        {
            try
            {
                using (var con = new SqlConnection(dbSqlConnectionString))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand(@"
                        IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ApplicationNugets].[" + solution + @"]') AND type in (N'U'))
                            DROP TABLE [ApplicationNugets].[" + solution + @"];

                        SET ANSI_NULLS ON;

                        SET QUOTED_IDENTIFIER ON;

                        CREATE TABLE [ApplicationNugets].[" + solution + @"](
	                        [Id] [int] IDENTITY(1,1) NOT NULL,
	                        [solutionName] [varchar](255) NOT NULL,
                            [createdate] [DATETIME] NULL,
                         CONSTRAINT [PK_" + solution + @"] PRIMARY KEY CLUSTERED 
                        (
	                        [Id] ASC
                        )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
                        ) ON [PRIMARY];", con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandTimeout = 30;
                        var iId = cmd.ExecuteNonQuery();
                    }

                }
            }
            catch { }
        }

        internal static IEnumerable<NugetDto> getAllNugets()
        {
            try
            {
                using (var con = new SqlConnection(dbSqlConnectionString))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand(@"
                            SELECT Id
                                  ,projectId
                                  ,nugetName
                                  ,nugetPath
                                  ,nugetVersion
                              FROM Sync.[ApplicationNugets].[" + nuget + @"]
                              ORDER BY nugetName"
                            , con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandTimeout = 30;

                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr != null && dr.HasRows)
                            {
                                var dt = new DataTable();
                                dt.Load(dr);
                                return ConvertToList<NugetDto>(dt).ToList();
                            }
                            else
                            {
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { }
            return null;
        }

        internal static IEnumerable<NugetDto> getNugetById(string iNugetId)
        {
            try
            {
                using (var con = new SqlConnection(dbSqlConnectionString))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand(@"
                            SELECT Id
                                  ,projectId
                                  ,nugetName
                                  ,nugetPath
                                  ,nugetVersion
                              FROM Sync.[ApplicationNugets].[" + nuget + @"]
                               WHERE Id = " + iNugetId +
                               " order by nugetName"
                            , con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandTimeout = 30;

                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr != null && dr.HasRows)
                            {
                                var dt = new DataTable();
                                dt.Load(dr);
                                return ConvertToList<NugetDto>(dt).ToList();
                            }
                            else
                            {
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { }
            return null;
        }

        internal static IEnumerable<NugetDto> getNugetByProjectId(string iProjectId)
        {
            try
            {
                using (var con = new SqlConnection(dbSqlConnectionString))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand(@"
                            SELECT Id
                                  ,projectId
                                  ,nugetName
                                  ,nugetPath
                                  ,nugetVersion
                              FROM Sync.[ApplicationNugets].[" + nuget + @"]
                               WHERE projectId = " + iProjectId +
                               " order by nugetName"
                            , con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandTimeout = 30;

                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr != null && dr.HasRows)
                            {
                                var dt = new DataTable();
                                dt.Load(dr);
                                return ConvertToList<NugetDto>(dt).ToList();
                            }
                            else
                            {
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { }
            return null;
        }

        internal static IEnumerable<SolutionNugetDto> getNugetBySolutionName(string pSolutionName)
        {
            try
            {
                using (var con = new SqlConnection(dbSqlConnectionString))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand(@"
                            SELECT s.solutionName
                                  ,p.projectName
                                  ,p.netVersion
                                  ,p.isNuget
                                  ,n.nugetName
                                  ,n.nugetPath
                                  ,n.nugetVersion
                              FROM [ApplicationNugets].[" + nuget + @"] n
                                INNER JOIN [ApplicationNugets].[" + project + @"] p
                                    ON p.id = n.projectId
                                INNER JOIN [ApplicationNugets].[" + solution + @"] s
                                    ON s.id = p.solutionId
                               WHERE s.SolutionName = '" + pSolutionName + "'" +
                               " order by s.SolutionName, n.nugetName"
                            , con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandTimeout = 30;

                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr != null && dr.HasRows)
                            {
                                var dt = new DataTable();
                                dt.Load(dr);
                                return ConvertToList<SolutionNugetDto>(dt).ToList();
                            }
                            else
                            {
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { }
            return null;
        }

        internal static IEnumerable<SolutionNugetDto> getSolutionsByNugetName(string pNugetName)
        {
            try
            {
                using (var con = new SqlConnection(dbSqlConnectionString))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand(@"
                            SELECT s.solutionName
                                  ,p.projectName
                                  ,p.netVersion
                                  ,p.isNuget
                                  ,n.nugetName
                                  ,n.nugetPath
                                  ,n.nugetVersion
                              FROM [ApplicationNugets].[" + solution + @"] s
                                INNER JOIN [ApplicationNugets].[" + project + @"] p
                                    ON s.id = p.solutionId
                                INNER JOIN [ApplicationNugets].[" + nuget + @"] n
                                    ON p.id = n.projectId
                               WHERE n.NugetName = '" + pNugetName + "'" +
                               " order by s.SolutionName, n.nugetName"
                            , con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandTimeout = 30;

                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr != null && dr.HasRows)
                            {
                                var dt = new DataTable();
                                dt.Load(dr);
                                return ConvertToList<SolutionNugetDto>(dt).ToList();
                            }
                            else
                            {
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { }
            return null;
        }

        internal static int upSertNuget(string pId, string pProjectId, string pNugetName, string pNugetPath, string pNugetVersion)
        {
            int iId = -1;
            try
            {
                using (var con = new SqlConnection(dbSqlConnectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    if (pId == "0")
                    {

                        using (cmd = new SqlCommand(@"
                         INSERT INTO [ApplicationNugets].[" + nuget + @"]
				               (projectId
				               ,nugetName
				               ,nugetPath
				               ,nugetVersion
                               ,createdate)
			             VALUES
				               (" + pProjectId +
                               ",'" + pNugetName + "'" +
                               ",'" + pNugetPath + "'" +
                               ",'" + pNugetVersion + "'" +
                               ", getdate());" +
                        "SELECT SCOPE_IDENTITY() as ID"
                            , con))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandTimeout = 30;
                            using (var dr = cmd.ExecuteReader())
                            {
                                if (dr != null && dr.HasRows)
                                {
                                    var dt = new DataTable();
                                    dt.Load(dr);
                                    var insId = dt.Rows[0]["ID"];
                                    return int.Parse(insId.ToString());
                                }
                                else
                                {
                                }
                            }
                        }
                    }
                    else
                    {
                        using (cmd = new SqlCommand(@"
		                    UPDATE [ApplicationNugets].[" + project + @"]
		                       SET projectId = '" + pProjectId + "'" +
                                  ",nugetName = '" + pNugetName + "'" +
                                  ",nugetPath = '" + pNugetPath + "'" +
                                  ",nugetVersion = '" + pNugetVersion + "'" +
                             " WHERE Id = " + pId
                            , con))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandTimeout = 30;
                            iId = cmd.ExecuteNonQuery();
                        }
                    }
                    return iId;
                }
            }
            catch (Exception ex) { }
            return iId;
        }

        internal static IEnumerable<SolutionDto> getAllSolutions()
        {
            try
            {
                using (var con = new SqlConnection(dbSqlConnectionString))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand(@"
                            SELECT Id
                                  ,solutionName
                              FROM [ApplicationNugets].[" + solution + @"]
                              ORDER BY solutionName"
                            , con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandTimeout = 30;

                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr != null && dr.HasRows)
                            {
                                var dt = new DataTable();
                                dt.Load(dr);
                                return ConvertToList<SolutionDto>(dt).ToList();
                            }
                            else
                            {
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { }
            return null;
        }

        internal static IEnumerable<SolutionDto> getSolutionById(string pId)
        {
            try
            {
                using (var con = new SqlConnection(dbSqlConnectionString))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand(@"
                            SELECT Id
                                  ,solutionName
                              FROM [ApplicationNugets].[" + solution + @"]
                              WHERE Id = " +pId
                            , con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandTimeout = 30;

                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr != null && dr.HasRows)
                            {
                                var dt = new DataTable();
                                dt.Load(dr);
                                return ConvertToList<SolutionDto>(dt).ToList();
                            }
                            else
                            {
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { }
            return null;
        }

        internal static IEnumerable<SolutionDto> getSolutionByName(string pSolutionName)
        {
            try
            {
                using (var con = new SqlConnection(dbSqlConnectionString))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand(@"
                            SELECT Id
                                  ,solutionName
                              FROM [ApplicationNugets].[" + solution + @"]
                              WHERE solutionName = '" + pSolutionName + "'"
                            , con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandTimeout = 30;

                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr != null && dr.HasRows)
                            {
                                var dt = new DataTable();
                                dt.Load(dr);
                                return ConvertToList<SolutionDto>(dt).ToList();
                            }
                            else
                            {
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { }
            return null;
        }

        internal static int UpSertSolution(string pId, string pSolutionName)
        {
            var iId = -1;
            try
            {
                using (var con = new SqlConnection(dbSqlConnectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    if (pId == "0")
                    {

                        using (cmd = new SqlCommand(@"
		                    INSERT INTO [ApplicationNugets].[" + solution + @"]
                               (solutionName
                                ,createdate)
                            VALUES
                               ('" + pSolutionName + "'" +
                               ", getdate());" +
                        "SELECT SCOPE_IDENTITY() as ID"
                            , con))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandTimeout = 30;
                            using (var dr = cmd.ExecuteReader())
                            {
                                if (dr != null && dr.HasRows)
                                {
                                    var dt = new DataTable();
                                    dt.Load(dr);
                                    var insId = dt.Rows[0]["ID"];
                                    return int.Parse(insId.ToString());
                                }
                                else
                                {
                                }
                            }
                        }
                    }
                    else
                    {
                        using (cmd = new SqlCommand(@"
		                    UPDATE [ApplicationNugets].[" + solution + @"]
		                       SET solutionName = '" + pSolutionName + "'" +
                             " WHERE Id = " + pId
                            , con))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandTimeout = 30;
                            iId = cmd.ExecuteNonQuery();
                        }
                    }
                    return iId;
                }
            }
            catch (Exception ex) { }
            return iId;
        }

        internal static IEnumerable<SolutionProjectDto> getAllProjects()
        {
            try
            {
                using (var con = new SqlConnection(dbSqlConnectionString))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand(@"
                            SELECT p.Id
                                  ,s.solutionName
                                  ,p.Id as ProjectId
                                  ,p.projectName
                                  ,p.projectPath
                                  ,p.netVersion
                                  ,p.isNuget
                              FROM [ApplicationNugets].[" + project + @"] p 
                              INNER JOIN [ApplicationNugets].[" + solution + @"] s
                                on p.solutionId = s.id
                              ORDER BY solutionName"
                            , con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandTimeout = 30;

                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr != null && dr.HasRows)
                            {
                                var dt = new DataTable();
                                dt.Load(dr);
                                return ConvertToList<SolutionProjectDto>(dt).ToList();
                            }
                            else
                            {
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { }
            return null;
        }

        internal static IEnumerable<ProjectDto> getProjectById(string iId)
        {
            try
            {
                using (var con = new SqlConnection(dbSqlConnectionString))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand(@"
                            SELECT p.Id
                                  ,s.solutionName
                                  ,p.projectName
                                  ,p.projectPath
                                  ,p.netVersion
                                  ,p.isNuget
                              FROM [ApplicationNugets].[" + project + @"] p 
                              INNER JOIN [ApplicationNugets].[" + solution + @"] s
                                on p.solutionId = s.id
                              WHERE p.Id = " + iId +
                               " order by projectName"
                            , con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandTimeout = 30;

                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr != null && dr.HasRows)
                            {
                                var dt = new DataTable();
                                dt.Load(dr);
                                return ConvertToList<ProjectDto>(dt).ToList();
                            }
                            else
                            {
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { }
            return null;
        }

        internal static IEnumerable<ProjectDto> getProjectByProjectName(string sProjectName)
        {
            try
            {
                using (var con = new SqlConnection(dbSqlConnectionString))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand(@"
                            SELECT p.Id
                                  ,s.solutionName
                                  ,p.projectName
                                  ,p.projectPath
                                  ,p.netVersion
                                  ,p.isNuget
                              FROM [ApplicationNugets].[" + project + @"] p 
                              INNER JOIN [ApplicationNugets].[" + solution + @"] s
                                on p.solutionId = s.id
                              WHERE p.projectName = '" + sProjectName +
                               "' order by projectName"
                            , con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandTimeout = 30;

                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr != null && dr.HasRows)
                            {
                                var dt = new DataTable();
                                dt.Load(dr);
                                return ConvertToList<ProjectDto>(dt).ToList();
                            }
                            else
                            {
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { }
            return null;
        }

        internal static IEnumerable<SolutionProjectDto> getProjectBySolutionAndProjectName(string sSolutionName, string sProjectName)
        {
            try
            {
                using (var con = new SqlConnection(dbSqlConnectionString))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand(@"
                            SELECT s.Id
                                  ,s.solutionName
                                  ,p.projectId
                                  ,p.projectName
                                  ,p.projectPath
                                  ,p.netVersion
                                  ,p.isNuget
                              FROM [ApplicationNugets].[" + solution + @"] s 
                                INNER JOIN [ApplicationNugets].[" + project + @"] p
                                    ON s.Id = p.solutionId
                              WHERE s.solutionName = '" + sSolutionName +
                              "' and p.projectName = '" + sProjectName +
                               "' order by solutionName, projectName"
                            , con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandTimeout = 30;

                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr != null && dr.HasRows)
                            {
                                var dt = new DataTable();
                                dt.Load(dr);
                                return ConvertToList<SolutionProjectDto>(dt).ToList();
                            }
                            else
                            {
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { }
            return null;
        }

        internal static int UpSertProject(string pId, string pSolutionId, string pProjectName, string pProjectPath, string pNetVersion, string pIsNuget)
        {
            var iId = -1;
            try
            {
                using (var con = new SqlConnection(dbSqlConnectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    if (pId == "0")
                    {

                        using (cmd = new SqlCommand(@"
		                    INSERT INTO [ApplicationNugets].[" + project + @"]
                               (solutionId
                               ,projectName
                               ,projectPath
                               ,netVersion
                               ,isNuget
                               ,createdate)
                            VALUES
                               (" + pSolutionId +
                               ",'" + pProjectName + "'" +
                               ",'" + pProjectPath + "'" +
                               ",'" + pNetVersion + "'" +
                               "," + pIsNuget +
                               ", getdate());" +
                        "SELECT SCOPE_IDENTITY() as ID"
                            , con))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandTimeout = 30;
                            using (var dr = cmd.ExecuteReader())
                            {
                                if (dr != null && dr.HasRows)
                                {
                                    var dt = new DataTable();
                                    dt.Load(dr);
                                    var insId = dt.Rows[0]["ID"];
                                    return int.Parse(insId.ToString());
                                }
                                else
                                {
                                }
                            }
                        }
                    }
                    else
                    {
                        using (cmd = new SqlCommand(@"
		                    UPDATE [ApplicationNugets].[" + project + @"]
		                       SET solutionId = " + pSolutionId +
                                  ",projectName = '" + pProjectName + "'" +
                                  ",projectPath = '" + pProjectPath + "'" +
                                  ",netVersion = '" + pNetVersion + "'" +
                                  ",isNuget = " + pIsNuget +
                             " WHERE Id = " + pId
                            , con))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandTimeout = 30;
                            iId = cmd.ExecuteNonQuery();
                        }
                    }
                    return iId;
                }
            }
            catch (Exception ex) { }
            return iId;
        }

        internal static void UpdateIsNuget()
        {
            var iId = -1;
            try
            {
                using (var con = new SqlConnection(dbSqlConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(@"
		                update  [Sync].[ApplicationNugets].[" + project + @"] p set [isNuget] = 1
                            where projectName in (select nugetName from [Sync].[ApplicationNugets].[" + nuget + @"] where nugetPath like '%packages%')
                            and isNuget = 0"
                        , con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandTimeout = 30;
                        iId = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch{ }
        }

        internal static void UpdateIsNugetName(string nugetname)
        {
            var iId = -1;
            try
            {
                using (var con = new SqlConnection(dbSqlConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(@"
		                update  [Sync].[ApplicationNugets].[" + project + @"] set [isNuget] = 1
                            where projectName = '" + nugetname +"'"
                        , con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandTimeout = 30;
                        iId = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch { }
        }

        internal static void UpdateIsNugetNameVersion(string nugetname, string solutionId)
        {
            var iId = -1;
            try
            {
                using (var con = new SqlConnection(dbSqlConnectionString))
                {
                    con.Open();
                   
                    using (SqlCommand cmd = new SqlCommand(@"
		                update  [Sync].[ApplicationNugets].[" + project + @"] set [isNuget] = 1 
                             where projectName = '" + nugetname + "' and solutionid = " + solutionId
                        , con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandTimeout = 30;
                        iId = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch { }
        }

        private static List<T> ConvertToList<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }

        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name.ToLower() == column.ColumnName.ToLower())
                    {
                        pro.SetValue(obj, dr[column.ColumnName]);
                        break;
                    }
                    else
                        continue;
                }
            }
            return obj;
        }

        public static List<T> ConvertToList1<T>(DataTable dt)
        {
            var columnNames = dt.Columns.Cast<DataColumn>()
                    .Select(c => c.ColumnName)
                    .ToList();
            var properties = typeof(T).GetProperties();
            return dt.AsEnumerable().Select(row =>
            {
                var objT = Activator.CreateInstance<T>();
                foreach (var pro in properties)
                {
                    if (columnNames.Contains(pro.Name))
                    {
                        PropertyInfo pI = objT.GetType().GetProperty(pro.Name);
                        pro.SetValue(objT, row[pro.Name] == DBNull.Value ? null : Convert.ChangeType(row[pro.Name], pI.PropertyType));
                    }
                }
                return objT;
            }).ToList();
        }
        #endregion
    }
}
