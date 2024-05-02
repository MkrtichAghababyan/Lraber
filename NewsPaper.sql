create Table Articles(
Id int identity primary key(Id),
Title nvarchar(max),
[Image] varbinary(max) null,
Info nvarchar(max),
IsDeleted bit,
UserId int,
foreign key(UserId) references Users(Id)
);

/*Database Architecture*/