ALTER TABLE dbo.[PURGROUP] NOCHECK CONSTRAINT ALL;

SET XACT_ABORT ON;
BEGIN TRANSACTION;

--Delete records from tables
DELETE FROM dbo.[PURGROUP]  ;

--Add records to [PURGROUP]
insert into [PURGROUP](EKGRP,USERID) values('Y01','BuyerAdmin')
insert into [PURGROUP](EKGRP,USERID) values('Y01','BuyerOper')
insert into [PURGROUP](EKGRP,USERID) values('Y01','BuyerVwer')

COMMIT;

ALTER TABLE dbo.[PURGROUP] CHECK CONSTRAINT ALL;
