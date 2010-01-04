using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Collections.ObjectModel;

using System.Configuration;
using System.IO;

using System.Data.SqlClient;
using System.Data.SqlTypes;


namespace GetDateSql
{
    class Program
    {
        static void Main(string[] args)
        {
           // GetAttributeValue();
          //return;
            //GetInspectionPlanning();
            //return;
           // GetLayerFarmPlanning();
           // return;
            string sDB, sServer, sUser, sPwd;
            string sTableName,sWhere;

            sDB = ConfigurationManager.AppSettings["DB"];
            sServer = ConfigurationManager.AppSettings["SERVER"];
            sUser = ConfigurationManager.AppSettings["USER"];
            sPwd = ConfigurationManager.AppSettings["PWD"];
            sTableName = ConfigurationManager.AppSettings["TABLE_NAME"];
            sWhere = ConfigurationManager.AppSettings["WHERE"];

            SqlConnection m_Conn = new SqlConnection();
            //m_Conn.ConnectionString = "data source=" + sServer + ";Database=" + sDB + ";User ID=" + sUser + ";Pwd=" + sPwd;
            m_Conn.ConnectionString = @"Data Source=MA-HONGYU\SQLEXPRESS; Initial Catalog=eProcurement; Integrated Security=SSPI;";
            m_Conn.Open();

            string folderPath = Environment.CurrentDirectory + @"\data\";

            Collection<string> objTableColl = new Collection<string>();
            string sWhereClause = " ";

            if (!string.IsNullOrEmpty(sTableName)) 
            {
                objTableColl.Add(sTableName);
                sWhereClause = sWhere;

            }

            objTableColl.Add("[PURGROUP]");

//       sWhereClause = @" WHERE 
//                    usrpwd IN ('123456')
//                   ";




            

            Console.WriteLine("Starting...");

            using (StreamWriter sw = new StreamWriter(folderPath + "WF_Rount_Setting.sql", false))
            {
                int nJ;

                for (nJ = objTableColl.Count - 1; nJ >= 0; nJ--)
                {
                    sw.WriteLine("ALTER TABLE dbo." + objTableColl[nJ] + " NOCHECK CONSTRAINT ALL;");
                }

                sw.WriteLine();

                //sw.WriteLine("DECLARE @now DATETIME;");
                //sw.WriteLine("SET @now = getdate();");
                sw.WriteLine("SET XACT_ABORT ON;");
                sw.WriteLine("BEGIN TRANSACTION;");
                sw.WriteLine();

                sw.WriteLine("--Delete records from tables");
                for (nJ = objTableColl.Count - 1; nJ >= 0; nJ--)
                {
                    sw.WriteLine("DELETE FROM dbo." + objTableColl[nJ] + " " + sWhereClause + ";");
                }

                sw.WriteLine();

                for (nJ = 0; nJ < objTableColl.Count; nJ++)
                {
                    string sTable = objTableColl[nJ];

                    sw.WriteLine("--Add records to " + sTable);

                    string sSql = "select * from " + sTable + " " + sWhereClause;

                    SqlCommand cmd = new SqlCommand(sSql, m_Conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int nI;
                        string sSqlScript = "insert into " + sTable + "(";
                        for (nI = 0; nI < reader.FieldCount; nI++)
                        {
                            if (reader[nI].GetType() != System.Type.GetType("System.Byte[]"))
                            //if (reader[nI].GetType() != System.Type.GetType("System.Byte[]") && reader[nI].GetType() != System.Type.GetType("System.Int64"))
                            {
                                sSqlScript += reader.GetName(nI) + ",";
                            }
                        }
                        sSqlScript = sSqlScript.Substring(0, sSqlScript.Length - 1);
                        sSqlScript += ") values(";


                        for (nI = 0; nI < reader.FieldCount; nI++)
                        {
                            if (reader[nI].GetType() != System.Type.GetType("System.Byte[]"))
                            //if (reader[nI].GetType() != System.Type.GetType("System.Byte[]") && reader[nI].GetType() != System.Type.GetType("System.Int64"))
                            {
                                if (reader[nI].GetType() == System.Type.GetType("System.DBNull"))
                                {
                                    sSqlScript += "null,";
                                }
                                else if (string.Compare(reader.GetName(nI), "CREATED_ON", false) == 0)
                                {
                                    sSqlScript += "GETDATE(),";
                                }
                                else
                                {
                                    sSqlScript += "'" + EscapeSQL(reader[nI].ToString()) + "',";
                                }

                            }
                        }

                        sSqlScript = sSqlScript.Substring(0, sSqlScript.Length - 1);
                        sSqlScript += ")";

                        sw.WriteLine(sSqlScript);

                    }
                    reader.Close();
                    sw.WriteLine();
                }
                sw.WriteLine("COMMIT;");

                sw.WriteLine();

                for (nJ = objTableColl.Count - 1; nJ >= 0; nJ--)
                {
                    sw.WriteLine("ALTER TABLE dbo." + objTableColl[nJ] + " CHECK CONSTRAINT ALL;");
                }
            }


            m_Conn.Close();

            Console.WriteLine("Completed Successfully. Press any key to exit.");
            Console.ReadLine();

        }

        private static void GetLayerFarmPlanning() {
            string sDB, sServer, sUser, sPwd;

            sDB = ConfigurationManager.AppSettings["DB"];
            sServer = ConfigurationManager.AppSettings["SERVER"];
            sUser = ConfigurationManager.AppSettings["USER"];
            sPwd = ConfigurationManager.AppSettings["PWD"];

            SqlConnection m_Conn = new SqlConnection();
            m_Conn.ConnectionString = "data source=" + sServer + ";Database=" + sDB + ";User ID=" + sUser + ";Pwd=" + sPwd;
            m_Conn.Open();

            string folderPath = Environment.CurrentDirectory + @"\data\";

            Collection<string> objTableColl = new Collection<string>();

          
            objTableColl.Add("ISP_PROGRAMME");
            objTableColl.Add("ISP_PROGRAMME_ACTIVITY");
            objTableColl.Add("ISP_PROGRAMME_ACTIVITY_SAMPLE");

            string sWhereClause = " WHERE DEl_IND='N' AND ACTIVE_IND='Y'";

            Console.WriteLine("Starting...");

            using (StreamWriter sw = new StreamWriter(folderPath + "09_INSPECTION_PLANNING_LAYER_FARM.sql", false))
            {
                int nJ;

               

                //sw.WriteLine("DECLARE @now DATETIME;");
                //sw.WriteLine("SET @now = getdate();");
                sw.WriteLine("--Delete records from tables");
                for (nJ = objTableColl.Count - 1; nJ >= 0; nJ--)
                {
                    sw.WriteLine("DELETE FROM dbo." + objTableColl[nJ] + " " + sWhereClause + ";");
                }


                sw.WriteLine();

                for (nJ = 0; nJ < objTableColl.Count; nJ++)
                {
                    string sTable = objTableColl[nJ];

                    sw.WriteLine("--Add records to " + sTable);
                    sw.WriteLine("SET IDENTITY_INSERT dbo." + sTable + " ON");
                    string sSql = "select * from " + sTable + " " + sWhereClause;

                    SqlCommand cmd = new SqlCommand(sSql, m_Conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int nI;
                        string sSqlScript = "insert into " + sTable + "(";
                        for (nI = 0; nI < reader.FieldCount; nI++)
                        {
                           if (reader[nI].GetType() != System.Type.GetType("System.Byte[]"))
                            {
                                sSqlScript += reader.GetName(nI) + ",";
                            }
                        }
                        sSqlScript = sSqlScript.Substring(0, sSqlScript.Length - 1);
                        sSqlScript += ") values(";


                        for (nI = 0; nI < reader.FieldCount; nI++)
                        {
                            if (reader[nI].GetType() != System.Type.GetType("System.Byte[]"))
                            {
                                if (reader[nI].GetType() == System.Type.GetType("System.DBNull"))
                                {
                                    sSqlScript += "null,";
                                }
                                else if (string.Compare(reader.GetName(nI), "CREATED_ON", false) == 0)
                                {
                                    sSqlScript += "GETDATE(),";
                                }
                                else if (string.Compare(reader.GetName(nI), "CREATED_BY", false) == 0)
                                {
                                    sSqlScript += "'SYSTEM',";
                                }
                                else if (string.Compare(reader.GetName(nI), "UPDATED_ON", false) == 0)
                                {
                                    sSqlScript += "null,";
                                }
                                else if (string.Compare(reader.GetName(nI), "UPDATED_BY", false) == 0)
                                {
                                    sSqlScript += "null,";
                                }
                                else
                                {
                                    sSqlScript += "'" + EscapeSQL(reader[nI].ToString()) + "',";
                                }
                            }
                        }

                        sSqlScript = sSqlScript.Substring(0, sSqlScript.Length - 1);
                        sSqlScript += ")";

                        sw.WriteLine(sSqlScript);

                    }
                    reader.Close();
                    sw.WriteLine("SET IDENTITY_INSERT dbo." + sTable + " OFF");
                    sw.WriteLine();
                }

                
                sw.WriteLine();

                
            }


            m_Conn.Close();

            Console.WriteLine("Completed Successfully. Press any key to exit.");
            Console.ReadLine();

        }

        private static void GetInspectionPlanning() {
            string sDB, sServer, sUser, sPwd;

            sDB = ConfigurationManager.AppSettings["DB"];
            sServer = ConfigurationManager.AppSettings["SERVER"];
            sUser = ConfigurationManager.AppSettings["USER"];
            sPwd = ConfigurationManager.AppSettings["PWD"];

            SqlConnection m_Conn = new SqlConnection();
            m_Conn.ConnectionString = "data source=" + sServer + ";Database=" + sDB + ";User ID=" + sUser + ";Pwd=" + sPwd;
            m_Conn.Open();

            string sPlnUid = "8803A714-B891-427E-A47D-0663463DE00F";

            string folderPath = Environment.CurrentDirectory + @"\data\";

            Collection<string> objTableColl = new Collection<string>();
            Collection<string> objWhereColl = new Collection<string>();
            Collection<string> objIgnoreBigintColl = new Collection<string>();

            objTableColl.Add("ISP_PREMISEBASED_PROGRAM");
            objTableColl.Add("ISP_PREMISEBASED_ACTIVITY");
            objTableColl.Add("ISP_PREMISEBASED_ACTIVITY_SAMPLE");
            objTableColl.Add("ISP_PREMISEBASED_ACTIVITY_ASSIGNMENT");

            string sWhereClause_L1 = String.Format(@" WHERE PLN_UID='{0}'",sPlnUid);
            string sWhereClause_L2 = String.Format(@" WHERE PRG_UID IN
                                                    (SELECT PRG_UID FROM ISP_PREMISEBASED_PROGRAM 
                                                    WHERE PLN_UID='{0}')",sPlnUid);
            string sWhereClause_L3 = String.Format(@" WHERE ACTIVITY_UID IN
                                                    (SELECT ACTIVITY_UID FROM ISP_PREMISEBASED_ACTIVITY
                                                    WHERE PRG_UID IN
                                                    (SELECT PRG_UID FROM ISP_PREMISEBASED_PROGRAM 
                                                    WHERE PLN_UID='{0}'))", sPlnUid);
            objWhereColl.Add(sWhereClause_L1);
            objWhereColl.Add(sWhereClause_L2);
            objWhereColl.Add(sWhereClause_L3);
            objWhereColl.Add(sWhereClause_L3);

            objIgnoreBigintColl.Add("N");
            objIgnoreBigintColl.Add("N");
            objIgnoreBigintColl.Add("Y");
            objIgnoreBigintColl.Add("Y");


            Console.WriteLine("Starting...");

            using (StreamWriter sw = new StreamWriter(folderPath + "08_INSPECTION_PLANNING_NONLAYER_FARM.sql", false))
            {
                int nJ;

                for (nJ = objTableColl.Count - 1; nJ >= 0; nJ--)
                {
                    sw.WriteLine("ALTER TABLE dbo." + objTableColl[nJ] + " NOCHECK CONSTRAINT ALL;");
                }

                sw.WriteLine();

                //sw.WriteLine("DECLARE @now DATETIME;");
                //sw.WriteLine("SET @now = getdate();");
                sw.WriteLine("SET XACT_ABORT ON;");
                sw.WriteLine("BEGIN TRANSACTION;");
                sw.WriteLine();

                sw.WriteLine("--Delete records from tables");
                for (nJ = objTableColl.Count - 1; nJ >= 0; nJ--)
                {
                    sw.WriteLine("DELETE FROM dbo." + objTableColl[nJ] + " " + objWhereColl[nJ] + ";");
                }

                sw.WriteLine();

                for (nJ = 0; nJ < objTableColl.Count; nJ++)
                {
                    string sTable = objTableColl[nJ];
                    bool bIgnoreBigint = string.Compare(objIgnoreBigintColl[nJ], "Y", true) == 0 ? true : false; 

                    sw.WriteLine("--Add records to " + sTable);

                    string sSql = "select * from " + sTable + " " + objWhereColl[nJ];

                    SqlCommand cmd = new SqlCommand(sSql, m_Conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int nI;
                        string sSqlScript = "insert into " + sTable + "(";
                        for (nI = 0; nI < reader.FieldCount; nI++)
                        {
                            if (bIgnoreBigint)
                            {
                                if (reader[nI].GetType() != System.Type.GetType("System.Byte[]") && reader[nI].GetType() != System.Type.GetType("System.Int64"))
                                    sSqlScript += reader.GetName(nI) + ",";
                            }
                            else
                            {
                                if (reader[nI].GetType() != System.Type.GetType("System.Byte[]"))
                                    sSqlScript += reader.GetName(nI) + ",";
                            }
                        }
                        sSqlScript = sSqlScript.Substring(0, sSqlScript.Length - 1);
                        sSqlScript += ") values(";


                        for (nI = 0; nI < reader.FieldCount; nI++)
                        {
                            if (bIgnoreBigint)
                            {
                                if (reader[nI].GetType() != System.Type.GetType("System.Byte[]") && reader[nI].GetType() != System.Type.GetType("System.Int64"))
                                {
                                    if (reader[nI].GetType() == System.Type.GetType("System.DBNull"))
                                    {
                                        sSqlScript += "null,";
                                    }
                                    else if (string.Compare(reader.GetName(nI), "CREATED_ON", false) == 0)
                                    {
                                        sSqlScript += "GETDATE(),";
                                    }
                                    else if (string.Compare(reader.GetName(nI), "CREATED_BY", false) == 0)
                                    {
                                        sSqlScript += "'SYSTEM',";
                                    }
                                    else if (string.Compare(reader.GetName(nI), "UPDATED_ON", false) == 0)
                                    {
                                        sSqlScript += "null,";
                                    }
                                    else if (string.Compare(reader.GetName(nI), "UPDATED_BY", false) == 0)
                                    {
                                        sSqlScript += "null,";
                                    }
                                    else
                                    {
                                        sSqlScript += "'" + EscapeSQL(reader[nI].ToString()) + "',";
                                    }
                                }
                            }
                            else
                            {
                                if (reader[nI].GetType() != System.Type.GetType("System.Byte[]"))
                                {
                                    if (reader[nI].GetType() == System.Type.GetType("System.DBNull"))
                                    {
                                        sSqlScript += "null,";
                                    }
                                    else if (string.Compare(reader.GetName(nI), "CREATED_ON", false) == 0)
                                    {
                                        sSqlScript += "GETDATE(),";
                                    }
                                    else if (string.Compare(reader.GetName(nI), "CREATED_BY", false) == 0)
                                    {
                                        sSqlScript += "'SYSTEM',";
                                    }
                                    else if (string.Compare(reader.GetName(nI), "UPDATED_ON", false) == 0)
                                    {
                                        sSqlScript += "null,";
                                    }
                                    else if (string.Compare(reader.GetName(nI), "UPDATED_BY", false) == 0)
                                    {
                                        sSqlScript += "null,";
                                    }
                                    else
                                    {
                                        sSqlScript += "'" + EscapeSQL(reader[nI].ToString()) + "',";
                                    }
                                }
                            }
                            
                            
                        }

                        sSqlScript = sSqlScript.Substring(0, sSqlScript.Length - 1);
                        sSqlScript += ")";

                        sw.WriteLine(sSqlScript);

                    }
                    reader.Close();
                    sw.WriteLine();
                }
                sw.WriteLine("COMMIT;");

                sw.WriteLine();

                for (nJ = objTableColl.Count - 1; nJ >= 0; nJ--)
                {
                    sw.WriteLine("ALTER TABLE dbo." + objTableColl[nJ] + " CHECK CONSTRAINT ALL;");
                }
            }


            m_Conn.Close();

            Console.WriteLine("Completed Successfully. Press any key to exit.");
            Console.ReadLine();
        
        }

        private static void GetAttributeValue() {
            string sDB, sServer, sUser, sPwd;

            sDB = ConfigurationManager.AppSettings["DB"];
            sServer = ConfigurationManager.AppSettings["SERVER"];
            sUser = ConfigurationManager.AppSettings["USER"];
            sPwd = ConfigurationManager.AppSettings["PWD"];

            SqlConnection m_Conn = new SqlConnection();
            m_Conn.ConnectionString = "data source=" + sServer + ";Database=" + sDB + ";User ID=" + sUser + ";Pwd=" + sPwd;
            m_Conn.Open();

            string folderPath = Environment.CurrentDirectory + @"\data\";

            Collection<string> objAttributeColl = new Collection<string>();

            //objAttributeColl.Add("	ISP_APP_QUOTA	");
            //objAttributeColl.Add("	ISP_QRT_PLACE	");
            //objAttributeColl.Add("	ISP_QRT_STATUS	");
            //objAttributeColl.Add("	ISP_QUOTA_STATUS	");
            //objAttributeColl.Add("	ISP_SERVICE_TYPE	");
            //objAttributeColl.Add("	ISP_ENQUIRY_TYPE	");
            //objAttributeColl.Add("	ISP_SPS_PURPOSE	");
            //objAttributeColl.Add("	ISP_EP12_REASON	");
            //objAttributeColl.Add("	ISP_SE06_QUALITY	");
            //objAttributeColl.Add("	ISP_RF01_PURPOSE	");
            //objAttributeColl.Add("	ISP_SE03_PURPOSE	");
            //objAttributeColl.Add("	ISP_EP03_PURPOSE	");
            //objAttributeColl.Add("	ISP_APSIB_PRODUCT_TYPE	");
            //objAttributeColl.Add("	OVERSEAS_FARM_TYPE	");
            //objAttributeColl.Add("	ANTIBIOTIC	");
            //objAttributeColl.Add("	HOUSING_TYPE	");
            //objAttributeColl.Add("	DRINKING_WATER_SOURCE	");
            //objAttributeColl.Add("	ISP_PHS_MEMBERSHIP_PROGRAMME	");
            //objAttributeColl.Add("	ISP_OFS_MEMBERSHIP_PROGRAMME	");
            //objAttributeColl.Add("	ENDANGERED_SPECIES_STATUS	");
            //objAttributeColl.Add("	VALUE_OF_CONSIGNMENT	");
            //objAttributeColl.Add("	INTENTION_TO_SMUGGLE	");
            //objAttributeColl.Add("	KNOWLEDGE_OF_OFFENCE	");
            //objAttributeColl.Add("	BACKGROUND_OF_OFFENDER	");
            //objAttributeColl.Add("	SENSITIVITY_OF_CASE	");
            //objAttributeColl.Add("	PAST_RECORD_OF_OFFENDER	");
            //objAttributeColl.Add("	DISPOSAL_OF_GOODS	");
            //objAttributeColl.Add("	ISP_PESTD_OPR_TRAING_IND	");
            //objAttributeColl.Add("	ISP_PESTD_OPR_PROF_TEST_RES	");
            //objAttributeColl.Add("	ISP_PESTD_OPR_MED_EXAM_RES	");
            //objAttributeColl.Add("	ISP_PESTD_PROD_INTEND_USE	");
            //objAttributeColl.Add("	ISP_PESTD_PROD_OWNER_TYPE	");
            //objAttributeColl.Add("	ISP_RA10_RATING	");
            //objAttributeColl.Add("	ISP_EA01_CHK_ITEM	");
            //objAttributeColl.Add("	ISP_EA01_OBSERVATION	");
            //objAttributeColl.Add("	ISP_EA01_ANIMAL_TYPE	");
            //objAttributeColl.Add("	ISP_EA01_DETAIN_HEALTH	");
            //objAttributeColl.Add("	ISP_EA02_CHK_ITEM	");
            //objAttributeColl.Add("	ISP_EA02_OBSERVATION	");
            //objAttributeColl.Add("	ISP_EA03_CHK_ITEM	");
            //objAttributeColl.Add("	ISP_EA03_OBSERVATION	");
            //objAttributeColl.Add("	ISP_EA03_SLAUGHTERHOUSE	");
            //objAttributeColl.Add("	ISP_EA03_SMPL_COLL	");
            //objAttributeColl.Add("	ISP_EA04_CHK_ITEM	");
            //objAttributeColl.Add("	ISP_EA04_OBSERVATION	");
            //objAttributeColl.Add("	ISP_EA05_CHK_ITEM	");
            //objAttributeColl.Add("	ISP_EA05_OBSERVATION	");
            //objAttributeColl.Add("	ISP_EA06_CMN_DROPDOWN	");
            //objAttributeColl.Add("	ISP_EA07_CMN_DROPDOWN	");
            //objAttributeColl.Add("	ISP_EA08_EGG_TYPE	");
            //objAttributeColl.Add("	ISP_EA08_EGG_SRC	");
            //objAttributeColl.Add("	ISP_EA09_CMN_DROPDOWN	");
            //objAttributeColl.Add("	ISP_EA09_SANITORY_CONDITION	");
            //objAttributeColl.Add("	ISP_EA11_CHK_ITEM	");
            //objAttributeColl.Add("	ISP_EA11_OBSERVATION	");
            //objAttributeColl.Add("	ISP_EA12_CHK_ITEM	");
            //objAttributeColl.Add("	ISP_EA12_OBSERVATION	");
            //objAttributeColl.Add("	ISP_SA01_DROPDOWN	");
            //objAttributeColl.Add("	ISP_SA02_DROPDOWN	");
            //objAttributeColl.Add("	ISP_SA03_COLDROOM_NO	");
            //objAttributeColl.Add("	ISP_SA04_DROPDOWN	");
            //objAttributeColl.Add("	ISP_SA05_LOCATION	");
            //objAttributeColl.Add("	ISP_SA08_LOCATION	");
            //objAttributeColl.Add("	ISP_EW01_PURPOSE	");
            //objAttributeColl.Add("	ISP_EW02_PURPOSE	");
            //objAttributeColl.Add("	ISP_SE04_HYGIENE	");
            //objAttributeColl.Add("	ISP_SE05_CMN_YESNO	");
            //objAttributeColl.Add("	ISP_SE05_CMN_OKNO	");
            //objAttributeColl.Add("	ISP_FF02_INSPECTION_RESULT	");
            //objAttributeColl.Add("	ISP_FF02_RESULT	");
            //objAttributeColl.Add("	ISP_FF02_CHKLST_RESULT	");
            //objAttributeColl.Add("	ISP_FF06_RATING	");
            //objAttributeColl.Add("	ISP_EP01_DETAINED	");
            //objAttributeColl.Add("	ISP_EP01_VISUAL_CHK	");
            //objAttributeColl.Add("	ISP_EP01_DOC_CHK	");
            //objAttributeColl.Add("	ISP_EP01_INSPN_DECISION	");
            //objAttributeColl.Add("	ISP_EP02_PESTICIDE	");
            //objAttributeColl.Add("	ISP_SI01_CONSIGNMENT_STATUS	");
            //objAttributeColl.Add("	ISP_SI01_DOC_CHK	");
            //objAttributeColl.Add("	ISP_SI01_DOC_CHK_FAIL_REASON	");
            //objAttributeColl.Add("	ISP_SI01_PHY_INSPN	");
            //objAttributeColl.Add("	ISP_SI01_PHY_INSPN_FAIL_REASON	");
            //objAttributeColl.Add("	ISP_SI01_SMPL_REQ	");
            //objAttributeColl.Add("	ISP_SI01_SMPL_COLL	");
            //objAttributeColl.Add("	ISP_SI01_RESAMPLE	");
            //objAttributeColl.Add("	ISP_SI01_INSPN_DECISION	");
            //objAttributeColl.Add("	ISP_SP02_INSPECTION_RESULT	");
            //objAttributeColl.Add("	ISP_SP02_PLANT_STATUS	");
            //objAttributeColl.Add("	ISP_SP02_PROCESS	");
            //objAttributeColl.Add("	ISP_SP02_PRODUCT	");
            //objAttributeColl.Add("	ISP_EW10_RATING	");
            //objAttributeColl.Add("	ISP_EW11_RATING	");
            //objAttributeColl.Add("	ISP_EW11_OVERALL	");
            //objAttributeColl.Add("	ISP_EW12_CMN_DROPDOWN	");
            //objAttributeColl.Add("	ISP_EW15_FISH_PCT_POOR	");
            //objAttributeColl.Add("	ISP_EW15_RATING	");
            //objAttributeColl.Add("	ISP_EW17_CMN_DROPDOWN	");
            //objAttributeColl.Add("	ISP_EW17_FISH_PCT_POOR	");
            //objAttributeColl.Add("	ISP_EW18_CMN_DROPDOWN	");
            //objAttributeColl.Add("	ISP_EW18_FISH_PCT_POOR	");
            //objAttributeColl.Add("	ISP_PE01_LATITUDE	");
            //objAttributeColl.Add("	ISP_PE01_LONGITUDE	");
            //objAttributeColl.Add("	ISP_PE01_PURPOSE	");
            //objAttributeColl.Add("	ISP_PE01_INSPN_NR_REASON	");
            //objAttributeColl.Add("	ISP_EP10_PEST	");
            //objAttributeColl.Add("	ISP_EP10_SYMPTOMS	");
            //objAttributeColl.Add("	ISP_EP10_SMPL_COLL	");
            //objAttributeColl.Add("	ISP_EP11_PEST	");
            //objAttributeColl.Add("	ISP_EP11_SYMPTOMS	");
            //objAttributeColl.Add("	ISP_EP11_SMPL_COLL	");
            //objAttributeColl.Add("	ISP_EP12_RISK	");
            //objAttributeColl.Add("	ISP_EP12_CMN_YESNO	");
            //objAttributeColl.Add("	ISP_EP12_PEST_CONTAMINATION	");
            //objAttributeColl.Add("	ISP_EP12_SMPL_RESULT	");
            //objAttributeColl.Add("	ISP_EP12_INSPN_RESULT	");
            //objAttributeColl.Add("	ISP_EP12_CONSIGNMENT_INFO	");
            //objAttributeColl.Add("	ISP_EP12_CMN_DROPDOWN	");
            //objAttributeColl.Add("	ISP_EP12_PLACE_INSPN	");
            //objAttributeColl.Add("	ISP_EP13_FIELD_STATION	");
            //objAttributeColl.Add("	ISP_EP13_FACILITY_COND	");
            //objAttributeColl.Add("	ISP_EP14_FACILITY_COND	");
            //objAttributeColl.Add("	ISP_EP15_SYMPTOMS	");
            //objAttributeColl.Add("	ISP_RS10_PREMISES_SANITATION	");
            //objAttributeColl.Add("	ISP_RS10_CMN_DROPDOWN	");
            //objAttributeColl.Add("	ISP_RS10_SEPARATE_ROOM_NO	");
            //objAttributeColl.Add("	ISP_RS10_MACHINE_NO	");
            //objAttributeColl.Add("	ISP_RS10_MAINTAIN_PATIENT_REC	");


            objAttributeColl.Add("	ISP_ARF_CRITERIA_CATEGORY	");
            objAttributeColl.Add("	ISP_ARF_CURRENT_STATUS	");
            objAttributeColl.Add("	ISP_ARF_GRADE	");
            objAttributeColl.Add("	ISP_ARF_IACUC_POSITION	");
            objAttributeColl.Add("	ISP_ARF_LICENCE_TYPE	");
            objAttributeColl.Add("	ISP_ARF_OTHER_POSITION	");
            objAttributeColl.Add("	ISP_ARF_PAYMENT_MODE	");
            objAttributeColl.Add("	ISP_ARF_POSITION	");
            objAttributeColl.Add("	ISP_ARF_PURPOSE	");
            objAttributeColl.Add("	ISP_ARF_REGISTRATION_TYPE	");
            objAttributeColl.Add("	ISP_ARF_SALUTATION_TYPE	");
            objAttributeColl.Add("	ISP_ARF_SPECIES	");
            objAttributeColl.Add("	ISP_FACILITY_NATURE	");
            objAttributeColl.Add("	ISP_SA05_PURPOSE	");
            objAttributeColl.Add("	ISP_VC_APPLICANT_POSITION	");
            objAttributeColl.Add("	ISP_VC_PARTNER_POSITION	");
            objAttributeColl.Add("	ISP_VC_PREMISE_TYPE	");
            objAttributeColl.Add("	ISP_VC_REGISTRATION_TYPE	");
            objAttributeColl.Add("	PLACE_OF_INSPECTION	");
            objAttributeColl.Add("	RSA2_LICENCE_TYPE	");
          


            Console.WriteLine("Starting...");

            using (StreamWriter sw = new StreamWriter(folderPath + "Attributes.sql", false))
            {
                int nJ;

                //sw.WriteLine("DECLARE @now DATETIME;");
                //sw.WriteLine("SET @now = getdate();");
                sw.WriteLine("SET XACT_ABORT ON;");
                sw.WriteLine("BEGIN TRANSACTION;");
                
                for (nJ = 0; nJ < objAttributeColl.Count; nJ++)
                {
                    sw.WriteLine();
                    string sTable = objAttributeColl[nJ];
                    string sSql = "select * from CMN_ATTRIBUTE where ATTRIBUTE_CD='" + sTable.Trim().ToUpper() + "'";
                    SqlCommand cmd = new SqlCommand(sSql, m_Conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (!reader.HasRows) 
                    {
                        sw.WriteLine("No record found for " + sTable);
                        continue;
                    }
                    
                    sw.WriteLine("--SN:" + Convert.ToSingle(nJ + 1) + " - " + sTable);
                    sw.WriteLine("--Delete records");
                    sw.WriteLine("DELETE FROM DBO.CMN_ATTRIBUTE_VALUE WHERE ATTRIBUTE_CD='" + sTable.Trim().ToUpper() + "';");
                    sw.WriteLine("DELETE FROM DBO.CMN_ATTRIBUTE WHERE ATTRIBUTE_CD='" + sTable.Trim().ToUpper() + "';");
                    sw.WriteLine("--Add records");

                    while (reader.Read())
                    {
                        int nI;
                        string sSqlScript = "INSERT INTO CMN_ATTRIBUTE(";
                        for (nI = 0; nI < reader.FieldCount; nI++)
                        {
                            if (reader[nI].GetType() != System.Type.GetType("System.Byte[]"))
                            //if (reader[nI].GetType() != System.Type.GetType("System.Byte[]") && reader[nI].GetType() != System.Type.GetType("System.Int64"))
                            {
                                sSqlScript += reader.GetName(nI) + ",";
                            }
                        }
                        sSqlScript = sSqlScript.Substring(0, sSqlScript.Length - 1);
                        sSqlScript += ") VALUES(";


                        for (nI = 0; nI < reader.FieldCount; nI++)
                        {
                            if (reader[nI].GetType() != System.Type.GetType("System.Byte[]"))
                            //if (reader[nI].GetType() != System.Type.GetType("System.Byte[]") && reader[nI].GetType() != System.Type.GetType("System.Int64"))
                            {
                                if (reader[nI].GetType() == System.Type.GetType("System.DBNull"))
                                {
                                    sSqlScript += "NULL,";
                                }
                                else if (string.Compare(reader.GetName(nI), "CREATED_ON", false) == 0)
                                {
                                    sSqlScript += "GETDATE(),";
                                }
                                else if (string.Compare(reader.GetName(nI), "UPDATED_ON", false) == 0)
                                {
                                    sSqlScript += "NULL,";
                                }
                                else if (string.Compare(reader.GetName(nI), "UPDATED_BY", false) == 0)
                                {
                                    sSqlScript += "NULL,";
                                }
                                else
                                {
                                    sSqlScript += "'" + EscapeSQL(reader[nI].ToString()) + "',";
                                }

                            }
                        }

                        sSqlScript = sSqlScript.Substring(0, sSqlScript.Length - 1);
                        sSqlScript += ")";

                        sw.WriteLine(sSqlScript);

                    }
                    reader.Close();

                    sSql = "select * from CMN_ATTRIBUTE_VALUE where ATTRIBUTE_CD='" + sTable.Trim().ToUpper() + "' order by ITEM_SEQ_NO";
                    cmd = new SqlCommand(sSql, m_Conn);
                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int nI;
                        string sSqlScript = "INSERT INTO CMN_ATTRIBUTE_VALUE(";
                        for (nI = 0; nI < reader.FieldCount; nI++)
                        {
                            //if (reader[nI].GetType() != System.Type.GetType("System.Byte[]"))
                            if (reader[nI].GetType() != System.Type.GetType("System.Byte[]") && reader[nI].GetType() != System.Type.GetType("System.Int64"))
                            {
                                sSqlScript += reader.GetName(nI) + ",";
                            }
                        }
                        sSqlScript = sSqlScript.Substring(0, sSqlScript.Length - 1);
                        sSqlScript += ") VALUES(";


                        for (nI = 0; nI < reader.FieldCount; nI++)
                        {
                            //if (reader[nI].GetType() != System.Type.GetType("System.Byte[]"))
                            if (reader[nI].GetType() != System.Type.GetType("System.Byte[]") && reader[nI].GetType() != System.Type.GetType("System.Int64"))
                            {
                                if (reader[nI].GetType() == System.Type.GetType("System.DBNull"))
                                {
                                    sSqlScript += "NULL,";
                                }
                                else if (string.Compare(reader.GetName(nI), "CREATED_ON", false) == 0)
                                {
                                    sSqlScript += "GETDATE(),";
                                }
                                else if (string.Compare(reader.GetName(nI), "UPDATED_ON", false) == 0)
                                {
                                    sSqlScript += "NULL,";
                                }
                                else if (string.Compare(reader.GetName(nI), "UPDATED_BY", false) == 0)
                                {
                                    sSqlScript += "NULL,";
                                }
                                else
                                {
                                    sSqlScript += "'" + EscapeSQL(reader[nI].ToString()) + "',";
                                }

                            }
                        }

                        sSqlScript = sSqlScript.Substring(0, sSqlScript.Length - 1);
                        sSqlScript += ")";

                        sw.WriteLine(sSqlScript);

                    }
                    reader.Close();
                  
                }
                sw.WriteLine("COMMIT;");

                sw.WriteLine();

               
            }


            m_Conn.Close();

            Console.WriteLine("Completed Successfully. Press any key to exit.");
            Console.ReadLine();
        
        }

        public static string EscapeSQL(string str)
        {
            string strReturn = string.Empty;
            if (!string.IsNullOrEmpty(str))
                strReturn = str.Replace("'", "''");
            return strReturn;
        }
    }
}
