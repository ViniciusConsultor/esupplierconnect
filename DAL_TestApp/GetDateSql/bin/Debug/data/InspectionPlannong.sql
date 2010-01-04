ALTER TABLE dbo.ISP_PREMISEBASED_ACTIVITY_ASSIGNMENT NOCHECK CONSTRAINT ALL;
ALTER TABLE dbo.ISP_PREMISEBASED_ACTIVITY_SAMPLE NOCHECK CONSTRAINT ALL;
ALTER TABLE dbo.ISP_PREMISEBASED_ACTIVITY NOCHECK CONSTRAINT ALL;
ALTER TABLE dbo.ISP_PREMISEBASED_PROGRAM NOCHECK CONSTRAINT ALL;

SET XACT_ABORT ON;
BEGIN TRANSACTION;

--Delete records from tables
DELETE FROM dbo.ISP_PREMISEBASED_ACTIVITY_ASSIGNMENT  WHERE ACTIVITY_UID IN
                                                    (SELECT ACTIVITY_UID FROM ISP_PREMISEBASED_ACTIVITY
                                                    WHERE PRG_UID IN
                                                    (SELECT PRG_UID FROM ISP_PREMISEBASED_PROGRAM 
                                                    WHERE PLN_UID='8803A714-B891-427E-A47D-0663463DE00F'));
DELETE FROM dbo.ISP_PREMISEBASED_ACTIVITY_SAMPLE  WHERE ACTIVITY_UID IN
                                                    (SELECT ACTIVITY_UID FROM ISP_PREMISEBASED_ACTIVITY
                                                    WHERE PRG_UID IN
                                                    (SELECT PRG_UID FROM ISP_PREMISEBASED_PROGRAM 
                                                    WHERE PLN_UID='8803A714-B891-427E-A47D-0663463DE00F'));
DELETE FROM dbo.ISP_PREMISEBASED_ACTIVITY  WHERE PRG_UID IN
                                                    (SELECT PRG_UID FROM ISP_PREMISEBASED_PROGRAM 
                                                    WHERE PLN_UID='8803A714-B891-427E-A47D-0663463DE00F');
DELETE FROM dbo.ISP_PREMISEBASED_PROGRAM  WHERE PLN_UID='8803A714-B891-427E-A47D-0663463DE00F';

--Add records to ISP_PREMISEBASED_PROGRAM
insert into ISP_PREMISEBASED_PROGRAM(PRG_UID,PLN_UID,OWNER_ORG_CD,OWNER_ORG_TYPE,PRG_CD,PRG_DESC,PRG_TYPE,LICENCE_RELATE_IND,ADJUST_DATE_IND,ACTIVE_IND,DEL_IND,MAINTAIN_IND,CREATED_BY,CREATED_ON,UPDATED_BY,UPDATED_ON) values('0c39d541-28e8-4f96-8265-22f92bc4e070','8803a714-b891-427e-a47d-0663463de00f','SE','L3','Prog-010','Ornamental Fish  Exporters’ Premises (AOFES)  Monitoring','P','N','Y','Y','N','Y','SYSTEM',GETDATE(),null,null)
insert into ISP_PREMISEBASED_PROGRAM(PRG_UID,PLN_UID,OWNER_ORG_CD,OWNER_ORG_TYPE,PRG_CD,PRG_DESC,PRG_TYPE,LICENCE_RELATE_IND,ADJUST_DATE_IND,ACTIVE_IND,DEL_IND,MAINTAIN_IND,CREATED_BY,CREATED_ON,UPDATED_BY,UPDATED_ON) values('4a364958-873e-4b80-b82c-33ca94b16a34','8803a714-b891-427e-a47d-0663463de00f','SE','L3','Prog-001','Layer Farm Monitoring','P','N','Y','Y','N','Y','SYSTEM',GETDATE(),null,null)
insert into ISP_PREMISEBASED_PROGRAM(PRG_UID,PLN_UID,OWNER_ORG_CD,OWNER_ORG_TYPE,PRG_CD,PRG_DESC,PRG_TYPE,LICENCE_RELATE_IND,ADJUST_DATE_IND,ACTIVE_IND,DEL_IND,MAINTAIN_IND,CREATED_BY,CREATED_ON,UPDATED_BY,UPDATED_ON) values('f9a2d2c9-7f9f-4725-90ff-5993eec4e8eb','8803a714-b891-427e-a47d-0663463de00f','SE','L3','Prog-007','Wild Bird (PU) Monitoring','P','N','Y','Y','N','Y','SYSTEM',GETDATE(),null,null)
insert into ISP_PREMISEBASED_PROGRAM(PRG_UID,PLN_UID,OWNER_ORG_CD,OWNER_ORG_TYPE,PRG_CD,PRG_DESC,PRG_TYPE,LICENCE_RELATE_IND,ADJUST_DATE_IND,ACTIVE_IND,DEL_IND,MAINTAIN_IND,CREATED_BY,CREATED_ON,UPDATED_BY,UPDATED_ON) values('cb92a4e1-c2df-4345-95a3-787417ddb38a','8803a714-b891-427e-a47d-0663463de00f','SE','L3','Prog-006','Wild Bird (SBG) Monitoring','P','N','Y','Y','N','Y','SYSTEM',GETDATE(),null,null)
insert into ISP_PREMISEBASED_PROGRAM(PRG_UID,PLN_UID,OWNER_ORG_CD,OWNER_ORG_TYPE,PRG_CD,PRG_DESC,PRG_TYPE,LICENCE_RELATE_IND,ADJUST_DATE_IND,ACTIVE_IND,DEL_IND,MAINTAIN_IND,CREATED_BY,CREATED_ON,UPDATED_BY,UPDATED_ON) values('b5f047b3-c4be-4b8b-b89e-9ff420145a63','8803a714-b891-427e-a47d-0663463de00f','SE','L3','Prog-008','Captive Bird Farm Monitoring','P','N','Y','Y','N','Y','SYSTEM',GETDATE(),null,null)
insert into ISP_PREMISEBASED_PROGRAM(PRG_UID,PLN_UID,OWNER_ORG_CD,OWNER_ORG_TYPE,PRG_CD,PRG_DESC,PRG_TYPE,LICENCE_RELATE_IND,ADJUST_DATE_IND,ACTIVE_IND,DEL_IND,MAINTAIN_IND,CREATED_BY,CREATED_ON,UPDATED_BY,UPDATED_ON) values('93a952bf-4e0b-486f-a729-a19e42a9bb59','8803a714-b891-427e-a47d-0663463de00f','SE','L3','Prog-005','Wild Bird (SBWR)  Monitoring','P','N','Y','Y','N','Y','SYSTEM',GETDATE(),null,null)
insert into ISP_PREMISEBASED_PROGRAM(PRG_UID,PLN_UID,OWNER_ORG_CD,OWNER_ORG_TYPE,PRG_CD,PRG_DESC,PRG_TYPE,LICENCE_RELATE_IND,ADJUST_DATE_IND,ACTIVE_IND,DEL_IND,MAINTAIN_IND,CREATED_BY,CREATED_ON,UPDATED_BY,UPDATED_ON) values('710a162b-f6c6-4ffa-857c-a3294ce656b4','8803a714-b891-427e-a47d-0663463de00f','SE','L3','Prog-003','Quail Farm Monitoring','P','N','Y','Y','N','Y','SYSTEM',GETDATE(),null,null)
insert into ISP_PREMISEBASED_PROGRAM(PRG_UID,PLN_UID,OWNER_ORG_CD,OWNER_ORG_TYPE,PRG_CD,PRG_DESC,PRG_TYPE,LICENCE_RELATE_IND,ADJUST_DATE_IND,ACTIVE_IND,DEL_IND,MAINTAIN_IND,CREATED_BY,CREATED_ON,UPDATED_BY,UPDATED_ON) values('1519dd07-c5ec-4017-b246-a991dfa7b51b','8803a714-b891-427e-a47d-0663463de00f','SE','L3','Prog-002','Layer Farm - Breeder Hatchery Monitoring','P','N','Y','Y','N','Y','SYSTEM',GETDATE(),null,null)
insert into ISP_PREMISEBASED_PROGRAM(PRG_UID,PLN_UID,OWNER_ORG_CD,OWNER_ORG_TYPE,PRG_CD,PRG_DESC,PRG_TYPE,LICENCE_RELATE_IND,ADJUST_DATE_IND,ACTIVE_IND,DEL_IND,MAINTAIN_IND,CREATED_BY,CREATED_ON,UPDATED_BY,UPDATED_ON) values('876548dc-0c35-452c-bb40-b82640b95de0','8803a714-b891-427e-a47d-0663463de00f','SE','L3','Prog-004-2','Ruminant Farm Monitoring - Goat','P','N','Y','Y','N','Y','SYSTEM',GETDATE(),null,null)
insert into ISP_PREMISEBASED_PROGRAM(PRG_UID,PLN_UID,OWNER_ORG_CD,OWNER_ORG_TYPE,PRG_CD,PRG_DESC,PRG_TYPE,LICENCE_RELATE_IND,ADJUST_DATE_IND,ACTIVE_IND,DEL_IND,MAINTAIN_IND,CREATED_BY,CREATED_ON,UPDATED_BY,UPDATED_ON) values('bfb9c4f8-f90d-40d0-ba97-bc74f8de0a7f','8803a714-b891-427e-a47d-0663463de00f','SE','L3','Prog-004-1','Ruminant Farm Monitoring - Cattle','P','N','Y','Y','N','Y','SYSTEM',GETDATE(),null,null)
insert into ISP_PREMISEBASED_PROGRAM(PRG_UID,PLN_UID,OWNER_ORG_CD,OWNER_ORG_TYPE,PRG_CD,PRG_DESC,PRG_TYPE,LICENCE_RELATE_IND,ADJUST_DATE_IND,ACTIVE_IND,DEL_IND,MAINTAIN_IND,CREATED_BY,CREATED_ON,UPDATED_BY,UPDATED_ON) values('c3c2539f-bc62-4825-9ef8-dc93f0fc2403','8803a714-b891-427e-a47d-0663463de00f','SE','L3','Prog-009','Oyster Farm Monitoring','P','N','Y','Y','N','Y','SYSTEM',GETDATE(),null,null)
insert into ISP_PREMISEBASED_PROGRAM(PRG_UID,PLN_UID,OWNER_ORG_CD,OWNER_ORG_TYPE,PRG_CD,PRG_DESC,PRG_TYPE,LICENCE_RELATE_IND,ADJUST_DATE_IND,ACTIVE_IND,DEL_IND,MAINTAIN_IND,CREATED_BY,CREATED_ON,UPDATED_BY,UPDATED_ON) values('b50b56e2-b20c-4f8b-a335-eb1097ced27e','8803a714-b891-427e-a47d-0663463de00f','SE','L3','Prog-011','Ornamental Fish Premises (Salmonella and V.Cholerea Free Scheme) Monitoring','P','N','Y','Y','N','Y','SYSTEM',GETDATE(),null,null)

--Add records to ISP_PREMISEBASED_ACTIVITY
insert into ISP_PREMISEBASED_ACTIVITY(ACTIVITY_UID,PRG_UID,ACTIVITY_NAME,ISP_TYPE,GRADE_RELATE_IND,TRADE_TYPE_RELATE_IND,CYCLE_TYPE,INTERVAL_QTY,INTERVAL_UOM,CREATE_OFT_IND,ADVANCED_CREATE_DAYS,ADVANCED_CREATE_UOM,FIRST_CASE_DAYS,FIXED_CREATE_DAYS,NEED_SAMPLING_IND,ADHOC_ONLY_IND,ADHOC_IND,ACTIVE_IND,MAINTAIN_IND,DEFAULT_GRADE,ASSIGN_TYPE,DEL_IND,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('914fbab1-36c7-438a-9ace-0c070803fb72','0c39d541-28e8-4f96-8265-22f92bc4e070','Ornamental Fish Exporters’Premises Sampling (AOFES)','SE02','N','N','F','6','M','Y','1','M','0','31','Y','N','Y','Y','Y',null,'S','N',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY(ACTIVITY_UID,PRG_UID,ACTIVITY_NAME,ISP_TYPE,GRADE_RELATE_IND,TRADE_TYPE_RELATE_IND,CYCLE_TYPE,INTERVAL_QTY,INTERVAL_UOM,CREATE_OFT_IND,ADVANCED_CREATE_DAYS,ADVANCED_CREATE_UOM,FIRST_CASE_DAYS,FIXED_CREATE_DAYS,NEED_SAMPLING_IND,ADHOC_ONLY_IND,ADHOC_IND,ACTIVE_IND,MAINTAIN_IND,DEFAULT_GRADE,ASSIGN_TYPE,DEL_IND,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('24090851-fc6d-4db6-b2ed-1259360f4d40','f9a2d2c9-7f9f-4725-90ff-5993eec4e8eb','Wild Bird AI Monitoring (P Ubin)','SE02','N','N','F','3','M','Y','1','M','0','31','Y','N','Y','Y','Y',null,'S','N',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY(ACTIVITY_UID,PRG_UID,ACTIVITY_NAME,ISP_TYPE,GRADE_RELATE_IND,TRADE_TYPE_RELATE_IND,CYCLE_TYPE,INTERVAL_QTY,INTERVAL_UOM,CREATE_OFT_IND,ADVANCED_CREATE_DAYS,ADVANCED_CREATE_UOM,FIRST_CASE_DAYS,FIXED_CREATE_DAYS,NEED_SAMPLING_IND,ADHOC_ONLY_IND,ADHOC_IND,ACTIVE_IND,MAINTAIN_IND,DEFAULT_GRADE,ASSIGN_TYPE,DEL_IND,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('6bdef819-e65e-4147-9be5-1af39f11a928','93a952bf-4e0b-486f-a729-a19e42a9bb59','Wild Bird AI Monitoring (SBWR)','SE02','N','N','F','1','W','Y','1','M','0','31','Y','N','Y','Y','Y',null,'S','N',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY(ACTIVITY_UID,PRG_UID,ACTIVITY_NAME,ISP_TYPE,GRADE_RELATE_IND,TRADE_TYPE_RELATE_IND,CYCLE_TYPE,INTERVAL_QTY,INTERVAL_UOM,CREATE_OFT_IND,ADVANCED_CREATE_DAYS,ADVANCED_CREATE_UOM,FIRST_CASE_DAYS,FIXED_CREATE_DAYS,NEED_SAMPLING_IND,ADHOC_ONLY_IND,ADHOC_IND,ACTIVE_IND,MAINTAIN_IND,DEFAULT_GRADE,ASSIGN_TYPE,DEL_IND,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('ea261376-372b-4235-8506-210613be9f6d','4a364958-873e-4b80-b82c-33ca94b16a34','Layer Feed Monitoring','SE02','N','N','F','1','M','Y','1','M','0','31','Y','N','Y','Y','Y',null,'S','N',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY(ACTIVITY_UID,PRG_UID,ACTIVITY_NAME,ISP_TYPE,GRADE_RELATE_IND,TRADE_TYPE_RELATE_IND,CYCLE_TYPE,INTERVAL_QTY,INTERVAL_UOM,CREATE_OFT_IND,ADVANCED_CREATE_DAYS,ADVANCED_CREATE_UOM,FIRST_CASE_DAYS,FIXED_CREATE_DAYS,NEED_SAMPLING_IND,ADHOC_ONLY_IND,ADHOC_IND,ACTIVE_IND,MAINTAIN_IND,DEFAULT_GRADE,ASSIGN_TYPE,DEL_IND,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('11f25af9-a4fb-4648-bce8-33e0ea1e98c6','710a162b-f6c6-4ffa-857c-a3294ce656b4','Quail Salmonella Monitoring - (Layer)','SE02','N','N','F','2','W','Y','1','M','0','31','Y','N','Y','Y','Y',null,'S','N',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY(ACTIVITY_UID,PRG_UID,ACTIVITY_NAME,ISP_TYPE,GRADE_RELATE_IND,TRADE_TYPE_RELATE_IND,CYCLE_TYPE,INTERVAL_QTY,INTERVAL_UOM,CREATE_OFT_IND,ADVANCED_CREATE_DAYS,ADVANCED_CREATE_UOM,FIRST_CASE_DAYS,FIXED_CREATE_DAYS,NEED_SAMPLING_IND,ADHOC_ONLY_IND,ADHOC_IND,ACTIVE_IND,MAINTAIN_IND,DEFAULT_GRADE,ASSIGN_TYPE,DEL_IND,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('bc2c4a4b-06f2-4696-86ac-452d2f60f065','bfb9c4f8-f90d-40d0-ba97-bc74f8de0a7f','Cow Milk Monitoring','SE02','N','N','F','1','M','Y','1','M','0','31','Y','N','Y','Y','Y',null,'S','N',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY(ACTIVITY_UID,PRG_UID,ACTIVITY_NAME,ISP_TYPE,GRADE_RELATE_IND,TRADE_TYPE_RELATE_IND,CYCLE_TYPE,INTERVAL_QTY,INTERVAL_UOM,CREATE_OFT_IND,ADVANCED_CREATE_DAYS,ADVANCED_CREATE_UOM,FIRST_CASE_DAYS,FIXED_CREATE_DAYS,NEED_SAMPLING_IND,ADHOC_ONLY_IND,ADHOC_IND,ACTIVE_IND,MAINTAIN_IND,DEFAULT_GRADE,ASSIGN_TYPE,DEL_IND,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('bf982fd3-8531-4934-9787-4d70c0dd64ce','710a162b-f6c6-4ffa-857c-a3294ce656b4','Quail AI Monitoring','SE02','N','N','F','2','W','Y','1','M','0','31','Y','N','Y','Y','Y',null,'S','N',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY(ACTIVITY_UID,PRG_UID,ACTIVITY_NAME,ISP_TYPE,GRADE_RELATE_IND,TRADE_TYPE_RELATE_IND,CYCLE_TYPE,INTERVAL_QTY,INTERVAL_UOM,CREATE_OFT_IND,ADVANCED_CREATE_DAYS,ADVANCED_CREATE_UOM,FIRST_CASE_DAYS,FIXED_CREATE_DAYS,NEED_SAMPLING_IND,ADHOC_ONLY_IND,ADHOC_IND,ACTIVE_IND,MAINTAIN_IND,DEFAULT_GRADE,ASSIGN_TYPE,DEL_IND,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('2f7cca5d-d2b2-4127-8237-4e164b9faf4a','710a162b-f6c6-4ffa-857c-a3294ce656b4','Quail Feed Monitoring','SE02','N','N','F','1','M','Y','1','M','0','31','Y','N','Y','Y','Y',null,'S','N',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY(ACTIVITY_UID,PRG_UID,ACTIVITY_NAME,ISP_TYPE,GRADE_RELATE_IND,TRADE_TYPE_RELATE_IND,CYCLE_TYPE,INTERVAL_QTY,INTERVAL_UOM,CREATE_OFT_IND,ADVANCED_CREATE_DAYS,ADVANCED_CREATE_UOM,FIRST_CASE_DAYS,FIXED_CREATE_DAYS,NEED_SAMPLING_IND,ADHOC_ONLY_IND,ADHOC_IND,ACTIVE_IND,MAINTAIN_IND,DEFAULT_GRADE,ASSIGN_TYPE,DEL_IND,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('dbf847bd-02a0-4928-9d8b-518d9677f719','1519dd07-c5ec-4017-b246-a991dfa7b51b','Breeder-Hatchery Monitoring','SE02','N','N','F','1','W','Y','1','M','0','31','Y','N','Y','Y','Y',null,'S','N',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY(ACTIVITY_UID,PRG_UID,ACTIVITY_NAME,ISP_TYPE,GRADE_RELATE_IND,TRADE_TYPE_RELATE_IND,CYCLE_TYPE,INTERVAL_QTY,INTERVAL_UOM,CREATE_OFT_IND,ADVANCED_CREATE_DAYS,ADVANCED_CREATE_UOM,FIRST_CASE_DAYS,FIXED_CREATE_DAYS,NEED_SAMPLING_IND,ADHOC_ONLY_IND,ADHOC_IND,ACTIVE_IND,MAINTAIN_IND,DEFAULT_GRADE,ASSIGN_TYPE,DEL_IND,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('5e6b319b-ba1a-4c13-81f0-5563172ccc0f','0c39d541-28e8-4f96-8265-22f92bc4e070','Ornamental Fish Exporter s’ Premises Routine Inspection (AOFES)','SE02','N','N','F','1','M','Y','1','M','0','31','Y','N','Y','Y','Y',null,'S','N',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY(ACTIVITY_UID,PRG_UID,ACTIVITY_NAME,ISP_TYPE,GRADE_RELATE_IND,TRADE_TYPE_RELATE_IND,CYCLE_TYPE,INTERVAL_QTY,INTERVAL_UOM,CREATE_OFT_IND,ADVANCED_CREATE_DAYS,ADVANCED_CREATE_UOM,FIRST_CASE_DAYS,FIXED_CREATE_DAYS,NEED_SAMPLING_IND,ADHOC_ONLY_IND,ADHOC_IND,ACTIVE_IND,MAINTAIN_IND,DEFAULT_GRADE,ASSIGN_TYPE,DEL_IND,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('a36d36f9-729b-46ff-8346-681c49658a87','4a364958-873e-4b80-b82c-33ca94b16a34','Layer SQES Egg Freshness Monitoring','SE02','N','N','F','1','M','Y','1','M','0','31','Y','N','Y','Y','Y',null,'S','N',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY(ACTIVITY_UID,PRG_UID,ACTIVITY_NAME,ISP_TYPE,GRADE_RELATE_IND,TRADE_TYPE_RELATE_IND,CYCLE_TYPE,INTERVAL_QTY,INTERVAL_UOM,CREATE_OFT_IND,ADVANCED_CREATE_DAYS,ADVANCED_CREATE_UOM,FIRST_CASE_DAYS,FIXED_CREATE_DAYS,NEED_SAMPLING_IND,ADHOC_ONLY_IND,ADHOC_IND,ACTIVE_IND,MAINTAIN_IND,DEFAULT_GRADE,ASSIGN_TYPE,DEL_IND,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('599c003d-4c20-4aeb-aff1-6fbd5d054f20','c3c2539f-bc62-4825-9ef8-dc93f0fc2403','Oyster Surveillance','SE02','N','N','F','1','W','Y','1','M','0','31','Y','N','Y','Y','Y',null,'S','N',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY(ACTIVITY_UID,PRG_UID,ACTIVITY_NAME,ISP_TYPE,GRADE_RELATE_IND,TRADE_TYPE_RELATE_IND,CYCLE_TYPE,INTERVAL_QTY,INTERVAL_UOM,CREATE_OFT_IND,ADVANCED_CREATE_DAYS,ADVANCED_CREATE_UOM,FIRST_CASE_DAYS,FIXED_CREATE_DAYS,NEED_SAMPLING_IND,ADHOC_ONLY_IND,ADHOC_IND,ACTIVE_IND,MAINTAIN_IND,DEFAULT_GRADE,ASSIGN_TYPE,DEL_IND,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('60d3fdbd-f1fd-4d17-97c1-719e156a02ba','876548dc-0c35-452c-bb40-b82640b95de0','Goat Health Monitoring','SE02','N','N','F','1','M','Y','1','M','0','31','Y','N','Y','Y','Y',null,'S','N',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY(ACTIVITY_UID,PRG_UID,ACTIVITY_NAME,ISP_TYPE,GRADE_RELATE_IND,TRADE_TYPE_RELATE_IND,CYCLE_TYPE,INTERVAL_QTY,INTERVAL_UOM,CREATE_OFT_IND,ADVANCED_CREATE_DAYS,ADVANCED_CREATE_UOM,FIRST_CASE_DAYS,FIXED_CREATE_DAYS,NEED_SAMPLING_IND,ADHOC_ONLY_IND,ADHOC_IND,ACTIVE_IND,MAINTAIN_IND,DEFAULT_GRADE,ASSIGN_TYPE,DEL_IND,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('7577ed31-af58-4f8b-8125-72883e62c16f','cb92a4e1-c2df-4345-95a3-787417ddb38a','Wild Bird AI Monitoring (SBG)','SE02','N','N','F','1','M','Y','1','M','0','31','Y','N','Y','Y','Y',null,'S','N',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY(ACTIVITY_UID,PRG_UID,ACTIVITY_NAME,ISP_TYPE,GRADE_RELATE_IND,TRADE_TYPE_RELATE_IND,CYCLE_TYPE,INTERVAL_QTY,INTERVAL_UOM,CREATE_OFT_IND,ADVANCED_CREATE_DAYS,ADVANCED_CREATE_UOM,FIRST_CASE_DAYS,FIXED_CREATE_DAYS,NEED_SAMPLING_IND,ADHOC_ONLY_IND,ADHOC_IND,ACTIVE_IND,MAINTAIN_IND,DEFAULT_GRADE,ASSIGN_TYPE,DEL_IND,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('6b19c32c-280b-4a5f-9a90-83ef0017be4a','710a162b-f6c6-4ffa-857c-a3294ce656b4','Quail Hatchery Monitoring','SE02','N','N','F','1','M','Y','1','M','0','31','Y','N','Y','Y','Y',null,'S','N',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY(ACTIVITY_UID,PRG_UID,ACTIVITY_NAME,ISP_TYPE,GRADE_RELATE_IND,TRADE_TYPE_RELATE_IND,CYCLE_TYPE,INTERVAL_QTY,INTERVAL_UOM,CREATE_OFT_IND,ADVANCED_CREATE_DAYS,ADVANCED_CREATE_UOM,FIRST_CASE_DAYS,FIXED_CREATE_DAYS,NEED_SAMPLING_IND,ADHOC_ONLY_IND,ADHOC_IND,ACTIVE_IND,MAINTAIN_IND,DEFAULT_GRADE,ASSIGN_TYPE,DEL_IND,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('352ffff0-2c84-4022-8bd9-9fa1fd8ab295','710a162b-f6c6-4ffa-857c-a3294ce656b4','Quail Salmonella Monitoring - (Grower)','SE02','N','N','F','1','M','Y','1','M','0','31','Y','N','Y','Y','Y',null,'S','N',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY(ACTIVITY_UID,PRG_UID,ACTIVITY_NAME,ISP_TYPE,GRADE_RELATE_IND,TRADE_TYPE_RELATE_IND,CYCLE_TYPE,INTERVAL_QTY,INTERVAL_UOM,CREATE_OFT_IND,ADVANCED_CREATE_DAYS,ADVANCED_CREATE_UOM,FIRST_CASE_DAYS,FIXED_CREATE_DAYS,NEED_SAMPLING_IND,ADHOC_ONLY_IND,ADHOC_IND,ACTIVE_IND,MAINTAIN_IND,DEFAULT_GRADE,ASSIGN_TYPE,DEL_IND,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('dd75bd2d-a804-454f-bcd6-a543b33e7686','b5f047b3-c4be-4b8b-b89e-9ff420145a63','Captive Bird Farm Sentinel Chicken Monitoring','SE02','N','N','F','1','M','Y','1','M','0','31','Y','N','Y','Y','Y',null,'S','N',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY(ACTIVITY_UID,PRG_UID,ACTIVITY_NAME,ISP_TYPE,GRADE_RELATE_IND,TRADE_TYPE_RELATE_IND,CYCLE_TYPE,INTERVAL_QTY,INTERVAL_UOM,CREATE_OFT_IND,ADVANCED_CREATE_DAYS,ADVANCED_CREATE_UOM,FIRST_CASE_DAYS,FIXED_CREATE_DAYS,NEED_SAMPLING_IND,ADHOC_ONLY_IND,ADHOC_IND,ACTIVE_IND,MAINTAIN_IND,DEFAULT_GRADE,ASSIGN_TYPE,DEL_IND,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('78268d3f-988f-42e0-8b3f-a8fc2910ceab','b50b56e2-b20c-4f8b-a335-eb1097ced27e','Ornamental Fish  Salmonella & Vibrio Cholera Monitoring','SE02','N','N','F','3','M','Y','1','M','0','31','Y','N','Y','Y','Y',null,'S','N',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY(ACTIVITY_UID,PRG_UID,ACTIVITY_NAME,ISP_TYPE,GRADE_RELATE_IND,TRADE_TYPE_RELATE_IND,CYCLE_TYPE,INTERVAL_QTY,INTERVAL_UOM,CREATE_OFT_IND,ADVANCED_CREATE_DAYS,ADVANCED_CREATE_UOM,FIRST_CASE_DAYS,FIXED_CREATE_DAYS,NEED_SAMPLING_IND,ADHOC_ONLY_IND,ADHOC_IND,ACTIVE_IND,MAINTAIN_IND,DEFAULT_GRADE,ASSIGN_TYPE,DEL_IND,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('3bec4a47-d5f3-4925-9bab-ae1ead86cd97','bfb9c4f8-f90d-40d0-ba97-bc74f8de0a7f','Cattle Health Monitoring','SE02','N','N','F','1','M','Y','1','M','0','31','Y','N','Y','Y','Y',null,'S','N',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY(ACTIVITY_UID,PRG_UID,ACTIVITY_NAME,ISP_TYPE,GRADE_RELATE_IND,TRADE_TYPE_RELATE_IND,CYCLE_TYPE,INTERVAL_QTY,INTERVAL_UOM,CREATE_OFT_IND,ADVANCED_CREATE_DAYS,ADVANCED_CREATE_UOM,FIRST_CASE_DAYS,FIXED_CREATE_DAYS,NEED_SAMPLING_IND,ADHOC_ONLY_IND,ADHOC_IND,ACTIVE_IND,MAINTAIN_IND,DEFAULT_GRADE,ASSIGN_TYPE,DEL_IND,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('16ea7b5e-811f-4e65-8290-bf527adb84be','4a364958-873e-4b80-b82c-33ca94b16a34','Layer AI Monitoring','SE02','N','N','F','2','W','Y','1','M','0','31','Y','N','Y','Y','Y',null,'S','N',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY(ACTIVITY_UID,PRG_UID,ACTIVITY_NAME,ISP_TYPE,GRADE_RELATE_IND,TRADE_TYPE_RELATE_IND,CYCLE_TYPE,INTERVAL_QTY,INTERVAL_UOM,CREATE_OFT_IND,ADVANCED_CREATE_DAYS,ADVANCED_CREATE_UOM,FIRST_CASE_DAYS,FIXED_CREATE_DAYS,NEED_SAMPLING_IND,ADHOC_ONLY_IND,ADHOC_IND,ACTIVE_IND,MAINTAIN_IND,DEFAULT_GRADE,ASSIGN_TYPE,DEL_IND,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('ffbdb45d-d44a-4b10-a75c-c28247d4e7ec','876548dc-0c35-452c-bb40-b82640b95de0','Goat Milk Monitoring','SE02','N','N','F','1','M','Y','1','M','0','31','Y','N','Y','Y','Y',null,'S','N',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY(ACTIVITY_UID,PRG_UID,ACTIVITY_NAME,ISP_TYPE,GRADE_RELATE_IND,TRADE_TYPE_RELATE_IND,CYCLE_TYPE,INTERVAL_QTY,INTERVAL_UOM,CREATE_OFT_IND,ADVANCED_CREATE_DAYS,ADVANCED_CREATE_UOM,FIRST_CASE_DAYS,FIXED_CREATE_DAYS,NEED_SAMPLING_IND,ADHOC_ONLY_IND,ADHOC_IND,ACTIVE_IND,MAINTAIN_IND,DEFAULT_GRADE,ASSIGN_TYPE,DEL_IND,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('59201e8b-d150-42a5-876b-e0a7f728dd45','4a364958-873e-4b80-b82c-33ca94b16a34','Layer Egg Monitoring','SE02','N','N','F','1','M','Y','1','M','0','31','Y','N','Y','Y','Y',null,'S','N',GETDATE(),'SYSTEM',null,null)

--Add records to ISP_PREMISEBASED_ACTIVITY_SAMPLE
insert into ISP_PREMISEBASED_ACTIVITY_SAMPLE(ACTIVITY_UID,PRODUCT_CD,QTY,REMARKS,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('2f7cca5d-d2b2-4127-8237-4e164b9faf4a','XAP0QLG','1','check for salmonella',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY_SAMPLE(ACTIVITY_UID,PRODUCT_CD,QTY,REMARKS,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('2f7cca5d-d2b2-4127-8237-4e164b9faf4a','XAP0QLL','3','check for salmonella/aflatoxins/antibiotic residues',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY_SAMPLE(ACTIVITY_UID,PRODUCT_CD,QTY,REMARKS,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('6b19c32c-280b-4a5f-9a90-83ef0017be4a','VBD0GALDOM','30','check for salmonella',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY_SAMPLE(ACTIVITY_UID,PRODUCT_CD,QTY,REMARKS,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('6b19c32c-280b-4a5f-9a90-83ef0017be4a','XAP0FFQL','1','check for salmonella',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY_SAMPLE(ACTIVITY_UID,PRODUCT_CD,QTY,REMARKS,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('a36d36f9-729b-46ff-8346-681c49658a87','VCE0CE','15','',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY_SAMPLE(ACTIVITY_UID,PRODUCT_CD,QTY,REMARKS,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('dbf847bd-02a0-4928-9d8b-518d9677f719','XAP0FFCK','1','check for salmonella',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY_SAMPLE(ACTIVITY_UID,PRODUCT_CD,QTY,REMARKS,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('dbf847bd-02a0-4928-9d8b-518d9677f719','XAP0CD','10','',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY_SAMPLE(ACTIVITY_UID,PRODUCT_CD,QTY,REMARKS,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('dbf847bd-02a0-4928-9d8b-518d9677f719','XAP0CS','50','',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY_SAMPLE(ACTIVITY_UID,PRODUCT_CD,QTY,REMARKS,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('ea261376-372b-4235-8506-210613be9f6d','VAF0PO','1','',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY_SAMPLE(ACTIVITY_UID,PRODUCT_CD,QTY,REMARKS,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('ea261376-372b-4235-8506-210613be9f6d','VAF0ZZ','1','',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY_SAMPLE(ACTIVITY_UID,PRODUCT_CD,QTY,REMARKS,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('16ea7b5e-811f-4e65-8290-bf527adb84be','XSP0TRCHL','15','15 (5 per flock for 3 flocks)',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY_SAMPLE(ACTIVITY_UID,PRODUCT_CD,QTY,REMARKS,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('16ea7b5e-811f-4e65-8290-bf527adb84be','XSP0CLCHL','15','15 (5 per flock for 3 flocks)',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY_SAMPLE(ACTIVITY_UID,PRODUCT_CD,QTY,REMARKS,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('352ffff0-2c84-4022-8bd9-9fa1fd8ab295','XAP0QLG','3','3-12, check for salmonella',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY_SAMPLE(ACTIVITY_UID,PRODUCT_CD,QTY,REMARKS,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('352ffff0-2c84-4022-8bd9-9fa1fd8ab295','XAP0FAQL','1','1 pool, check for salmonella',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY_SAMPLE(ACTIVITY_UID,PRODUCT_CD,QTY,REMARKS,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('11f25af9-a4fb-4648-bce8-33e0ea1e98c6','XAP0QLL','3','3-12, check for salmonella',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY_SAMPLE(ACTIVITY_UID,PRODUCT_CD,QTY,REMARKS,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('11f25af9-a4fb-4648-bce8-33e0ea1e98c6','XAP0FAQL','3','3 pools, check for salmonella',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY_SAMPLE(ACTIVITY_UID,PRODUCT_CD,QTY,REMARKS,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('6bdef819-e65e-4147-9be5-1af39f11a928','XSB0CLBDW','1','per bird, check for AI',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY_SAMPLE(ACTIVITY_UID,PRODUCT_CD,QTY,REMARKS,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('6bdef819-e65e-4147-9be5-1af39f11a928','XSB0FCBDW','1','per bird, check for AI',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY_SAMPLE(ACTIVITY_UID,PRODUCT_CD,QTY,REMARKS,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('7577ed31-af58-4f8b-8125-72883e62c16f','XSB0CLBDW','1','per bird, check for AI',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY_SAMPLE(ACTIVITY_UID,PRODUCT_CD,QTY,REMARKS,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('7577ed31-af58-4f8b-8125-72883e62c16f','XSB0FCBDW','1','per bird, check for AI',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY_SAMPLE(ACTIVITY_UID,PRODUCT_CD,QTY,REMARKS,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('7577ed31-af58-4f8b-8125-72883e62c16f','XZW0D','2','0-2, check for AI',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY_SAMPLE(ACTIVITY_UID,PRODUCT_CD,QTY,REMARKS,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('24090851-fc6d-4db6-b2ed-1259360f4d40','XSB0CLBDW','1','1 per bird, check for AI',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY_SAMPLE(ACTIVITY_UID,PRODUCT_CD,QTY,REMARKS,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('24090851-fc6d-4db6-b2ed-1259360f4d40','XSB0FCBDW','1','1 per bird, check for AI',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY_SAMPLE(ACTIVITY_UID,PRODUCT_CD,QTY,REMARKS,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('3bec4a47-d5f3-4925-9bab-ae1ead86cd97','XSZ0RECT','1','',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY_SAMPLE(ACTIVITY_UID,PRODUCT_CD,QTY,REMARKS,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('3bec4a47-d5f3-4925-9bab-ae1ead86cd97','XAZ0FACT','4','',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY_SAMPLE(ACTIVITY_UID,PRODUCT_CD,QTY,REMARKS,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('bc2c4a4b-06f2-4696-86ac-452d2f60f065','DMP0KAR0000','2','',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY_SAMPLE(ACTIVITY_UID,PRODUCT_CD,QTY,REMARKS,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('60d3fdbd-f1fd-4d17-97c1-719e156a02ba','XAZ0FAGO','4','',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY_SAMPLE(ACTIVITY_UID,PRODUCT_CD,QTY,REMARKS,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('60d3fdbd-f1fd-4d17-97c1-719e156a02ba','XSZ0REGO','1','',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY_SAMPLE(ACTIVITY_UID,PRODUCT_CD,QTY,REMARKS,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('ffbdb45d-d44a-4b10-a75c-c28247d4e7ec','DMP0KBR0000','2','',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY_SAMPLE(ACTIVITY_UID,PRODUCT_CD,QTY,REMARKS,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('599c003d-4c20-4aeb-aff1-6fbd5d054f20','FML0YX','60','',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY_SAMPLE(ACTIVITY_UID,PRODUCT_CD,QTY,REMARKS,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('914fbab1-36c7-438a-9ace-0c070803fb72','XZW0ZP','1','1 (bottle 100cc)',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY_SAMPLE(ACTIVITY_UID,PRODUCT_CD,QTY,REMARKS,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('914fbab1-36c7-438a-9ace-0c070803fb72','XFO0ZX','40','Other Species(40)',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY_SAMPLE(ACTIVITY_UID,PRODUCT_CD,QTY,REMARKS,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('914fbab1-36c7-438a-9ace-0c070803fb72','FFO0GO1GOLD','30','',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY_SAMPLE(ACTIVITY_UID,PRODUCT_CD,QTY,REMARKS,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('78268d3f-988f-42e0-8b3f-a8fc2910ceab','XZW0ZP','1','1 (bottle 500cc)',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY_SAMPLE(ACTIVITY_UID,PRODUCT_CD,QTY,REMARKS,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('bf982fd3-8531-4934-9787-4d70c0dd64ce','XSP0TRQL','15','15 (5 per flock for 3 flocks)',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY_SAMPLE(ACTIVITY_UID,PRODUCT_CD,QTY,REMARKS,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('bf982fd3-8531-4934-9787-4d70c0dd64ce','XSP0CLQL','15','15 (5 per flock for 3 flocks)',GETDATE(),'SYSTEM',null,null)

--Add records to ISP_PREMISEBASED_ACTIVITY_ASSIGNMENT
insert into ISP_PREMISEBASED_ACTIVITY_ASSIGNMENT(ACTIVITY_UID,USER_ID,USER_TYPE,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('2f7cca5d-d2b2-4127-8237-4e164b9faf4a','US3TTS1','P',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY_ASSIGNMENT(ACTIVITY_UID,USER_ID,USER_TYPE,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('6b19c32c-280b-4a5f-9a90-83ef0017be4a','US3TTS1','P',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY_ASSIGNMENT(ACTIVITY_UID,USER_ID,USER_TYPE,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('a36d36f9-729b-46ff-8346-681c49658a87','US3PEG1','P',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY_ASSIGNMENT(ACTIVITY_UID,USER_ID,USER_TYPE,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('dbf847bd-02a0-4928-9d8b-518d9677f719','US4TGH1','P',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY_ASSIGNMENT(ACTIVITY_UID,USER_ID,USER_TYPE,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('ea261376-372b-4235-8506-210613be9f6d','US3PEG1','P',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY_ASSIGNMENT(ACTIVITY_UID,USER_ID,USER_TYPE,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('16ea7b5e-811f-4e65-8290-bf527adb84be','US3LKC1','P',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY_ASSIGNMENT(ACTIVITY_UID,USER_ID,USER_TYPE,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('59201e8b-d150-42a5-876b-e0a7f728dd45','US3LKC1','P',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY_ASSIGNMENT(ACTIVITY_UID,USER_ID,USER_TYPE,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('352ffff0-2c84-4022-8bd9-9fa1fd8ab295','US3TTS1','P',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY_ASSIGNMENT(ACTIVITY_UID,USER_ID,USER_TYPE,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('11f25af9-a4fb-4648-bce8-33e0ea1e98c6','US3TTS1','P',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY_ASSIGNMENT(ACTIVITY_UID,USER_ID,USER_TYPE,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('6bdef819-e65e-4147-9be5-1af39f11a928','US3SKL1','P',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY_ASSIGNMENT(ACTIVITY_UID,USER_ID,USER_TYPE,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('6bdef819-e65e-4147-9be5-1af39f11a928','US4TGH1','P',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY_ASSIGNMENT(ACTIVITY_UID,USER_ID,USER_TYPE,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('7577ed31-af58-4f8b-8125-72883e62c16f','US3SKL1','P',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY_ASSIGNMENT(ACTIVITY_UID,USER_ID,USER_TYPE,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('7577ed31-af58-4f8b-8125-72883e62c16f','US4TGH1','P',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY_ASSIGNMENT(ACTIVITY_UID,USER_ID,USER_TYPE,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('24090851-fc6d-4db6-b2ed-1259360f4d40','US3SKL1','P',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY_ASSIGNMENT(ACTIVITY_UID,USER_ID,USER_TYPE,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('24090851-fc6d-4db6-b2ed-1259360f4d40','US4TGH1','P',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY_ASSIGNMENT(ACTIVITY_UID,USER_ID,USER_TYPE,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('dd75bd2d-a804-454f-bcd6-a543b33e7686','US3PEG1','P',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY_ASSIGNMENT(ACTIVITY_UID,USER_ID,USER_TYPE,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('3bec4a47-d5f3-4925-9bab-ae1ead86cd97','US3LKC1','P',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY_ASSIGNMENT(ACTIVITY_UID,USER_ID,USER_TYPE,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('bc2c4a4b-06f2-4696-86ac-452d2f60f065','US3LKC1','P',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY_ASSIGNMENT(ACTIVITY_UID,USER_ID,USER_TYPE,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('60d3fdbd-f1fd-4d17-97c1-719e156a02ba','US3LKC1','P',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY_ASSIGNMENT(ACTIVITY_UID,USER_ID,USER_TYPE,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('ffbdb45d-d44a-4b10-a75c-c28247d4e7ec','US3LKC1','P',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY_ASSIGNMENT(ACTIVITY_UID,USER_ID,USER_TYPE,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('599c003d-4c20-4aeb-aff1-6fbd5d054f20','US3SKL1','P',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY_ASSIGNMENT(ACTIVITY_UID,USER_ID,USER_TYPE,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('599c003d-4c20-4aeb-aff1-6fbd5d054f20','US4WMS1','P',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY_ASSIGNMENT(ACTIVITY_UID,USER_ID,USER_TYPE,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('914fbab1-36c7-438a-9ace-0c070803fb72','US3ICK1','P',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY_ASSIGNMENT(ACTIVITY_UID,USER_ID,USER_TYPE,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('914fbab1-36c7-438a-9ace-0c070803fb72','US3SKL1','S',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY_ASSIGNMENT(ACTIVITY_UID,USER_ID,USER_TYPE,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('5e6b319b-ba1a-4c13-81f0-5563172ccc0f','US3ICK1','P',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY_ASSIGNMENT(ACTIVITY_UID,USER_ID,USER_TYPE,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('5e6b319b-ba1a-4c13-81f0-5563172ccc0f','US3SKL1','S',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY_ASSIGNMENT(ACTIVITY_UID,USER_ID,USER_TYPE,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('78268d3f-988f-42e0-8b3f-a8fc2910ceab','US3ICK1','P',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY_ASSIGNMENT(ACTIVITY_UID,USER_ID,USER_TYPE,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('78268d3f-988f-42e0-8b3f-a8fc2910ceab','US3SKL1','S',GETDATE(),'SYSTEM',null,null)
insert into ISP_PREMISEBASED_ACTIVITY_ASSIGNMENT(ACTIVITY_UID,USER_ID,USER_TYPE,CREATED_ON,CREATED_BY,UPDATED_ON,UPDATED_BY) values('bf982fd3-8531-4934-9787-4d70c0dd64ce','US3LKC1','P',GETDATE(),'SYSTEM',null,null)

COMMIT;

ALTER TABLE dbo.ISP_PREMISEBASED_ACTIVITY_ASSIGNMENT CHECK CONSTRAINT ALL;
ALTER TABLE dbo.ISP_PREMISEBASED_ACTIVITY_SAMPLE CHECK CONSTRAINT ALL;
ALTER TABLE dbo.ISP_PREMISEBASED_ACTIVITY CHECK CONSTRAINT ALL;
ALTER TABLE dbo.ISP_PREMISEBASED_PROGRAM CHECK CONSTRAINT ALL;
