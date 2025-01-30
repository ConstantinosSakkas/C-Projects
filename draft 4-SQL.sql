CREATE TABLE GLEN.Assets (
    AssetID INT IDENTITY (1,1) NOT NULL ,
    SystemName VARCHAR(50) NOT NULL,
    Model VARCHAR(50) NOT NULL,
    Manufacturer VARCHAR(50) NOT NULL,
    Type VARCHAR(50) NOT NULL,
    IPAddress VARCHAR(20) NOT NULL,
    PurchaseDate DATETIME NOT NULL,  
    Notes TEXT NULL,             
    EmpID INT NOT NULL,          
    PRIMARY KEY (AssetID),
    FOREIGN KEY (EmpID) REFERENCES GLEN.Employees(EmpID)
);
