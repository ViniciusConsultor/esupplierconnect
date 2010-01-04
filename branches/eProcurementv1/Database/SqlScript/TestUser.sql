--Delete records from tables
DELETE FROM dbo.[USER]  WHERE usrpwd IN ('123456')

--Add records to [USER]
insert into [USER](USERID,USRNAM,USRPWD,USRROLE,USREMAIL,UPDTBY,UPDTDATE,USRSTAT,LIFNR,PROFTYP) values('Buyer1    ','Test Buyer 1','123456','Operator','Buyer1@www.com','mahy','20091223','A',null,'Buyer')
insert into [USER](USERID,USRNAM,USRPWD,USRROLE,USREMAIL,UPDTBY,UPDTDATE,USRSTAT,LIFNR,PROFTYP) values('BuyerAdmin','BuyerAdmin 1','123456','Administrator','qqq@DDF.COM','BuyerAdmin','20100103','A','          ','Buyer')
insert into [USER](USERID,USRNAM,USRPWD,USRROLE,USREMAIL,UPDTBY,UPDTDATE,USRSTAT,LIFNR,PROFTYP) values('BuyerOper ','BuyerOperator 1','123456','Operator','ERE@DFD.COM','BuyerOper','20100103','A','          ','Buyer')
insert into [USER](USERID,USRNAM,USRPWD,USRROLE,USREMAIL,UPDTBY,UPDTDATE,USRSTAT,LIFNR,PROFTYP) values('BuyerVwer ','BuyerView1','123456','Viewer','ERE@DFD.COM','BuyerVwer','20100103','A','          ','Buyer')
insert into [USER](USERID,USRNAM,USRPWD,USRROLE,USREMAIL,UPDTBY,UPDTDATE,USRSTAT,LIFNR,PROFTYP) values('super     ','System Admin 1 ','123456','Administrator','abC@dd.com','super','20100103','A','          ','System')
insert into [USER](USERID,USRNAM,USRPWD,USRROLE,USREMAIL,UPDTBY,UPDTDATE,USRSTAT,LIFNR,PROFTYP) values('Supplier1 ','Test Supplier 1','123456','Operator','Supplier1@www.com','mahy','20091223','A','0001      ','Supplier')
insert into [USER](USERID,USRNAM,USRPWD,USRROLE,USREMAIL,UPDTBY,UPDTDATE,USRSTAT,LIFNR,PROFTYP) values('SupplierAd','SupplierAdmin','123456','Administrator','ERE@DFD.COM','SupplierAd','20100103','A','0000010000','Supplier')
insert into [USER](USERID,USRNAM,USRPWD,USRROLE,USREMAIL,UPDTBY,UPDTDATE,USRSTAT,LIFNR,PROFTYP) values('SupplierOp','Supplier Operator 1','123456','Operator','ERE@DFD.COM','SupplierOp','20100103','A','0000010000','Supplier')
insert into [USER](USERID,USRNAM,USRPWD,USRROLE,USREMAIL,UPDTBY,UPDTDATE,USRSTAT,LIFNR,PROFTYP) values('SupplierVw','Supplier Viewer 1','123456','Viewer','ERE@DFD.COMd','SupplierVw','20100103','A','0000010000','Supplier')
insert into [USER](USERID,USRNAM,USRPWD,USRROLE,USREMAIL,UPDTBY,UPDTDATE,USRSTAT,LIFNR,PROFTYP) values('WHOperator','WH Operator 1','123456','Operator','ERE@DFD.COM','WHOperator','20100103','A','          ','WHUser')
insert into [USER](USERID,USRNAM,USRPWD,USRROLE,USREMAIL,UPDTBY,UPDTDATE,USRSTAT,LIFNR,PROFTYP) values('WHViewer  ','WH Viewer 1','123456','Viewer','ERE@DFD.COM','WHViewer','20100103','A','          ','WHUser')

--Delete records from tables
DELETE FROM dbo.[PURGROUP]  ;

--Add records to [PURGROUP]
insert into [PURGROUP](EKGRP,USERID) values('Y01','BuyerAdmin')
insert into [PURGROUP](EKGRP,USERID) values('Y01','BuyerOper')
insert into [PURGROUP](EKGRP,USERID) values('Y01','BuyerVwer')