CREATE TABLE RATES_JOURNAL
(
ID int IDENTITY(1,1) PRIMARY KEY,
APIID int ,
CURRENCYID int ,
PRICE nvarchar(255),
RATETIME datetime,
FOREIGN KEY (APIID) REFERENCES EXCHANGE_API(ID),
FOREIGN KEY (CURRENCYID) REFERENCES EXCHANGE_CURRENCY(ID)
)
