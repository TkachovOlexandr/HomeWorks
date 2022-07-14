drop table if exists Results;
drop table if exists Winner_Info;
drop table if exists Loser_Info;

create table Winner_Info
(
	Id int not null identity(1, 1) primary key,
	All_Soldiers int not null,
	Survivors int not null
);

create table Loser_Info
(
	Id int not null identity(1, 1) primary key,
	All_Soldiers int not null
);
create table Results
(
	Id int not null identity(1, 1) primary key,
	Winner_Id int not null,
	Loser_Id int not null,
	constraint fk_Winner_id foreign key (Winner_Id) references Winner_Info(Id),
	constraint fk_Loser_id foreign key (Loser_Id) references Loser_Info(Id)
);

select * from Winner_Info;
select * from Loser_Info;
select * from Results;