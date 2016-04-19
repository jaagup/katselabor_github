CREATE TABLE [dbo].[Table1]
(
	[Id] INT NOT NULL  PRIMARY KEY IDENTITY , 
    [name] VARCHAR(50) NULL, 
    [length] NCHAR(10) NULL, 
    [mass] DECIMAL NULL, 
    [sex] NCHAR(10) NULL, 
    [entryDate] DATETIME NULL
)
