# TestAlzaRestApi

Pro práci s daty je potřeba vytvořit databázi. V repozitáři jsou tři soubory CreateDatabase.sql, CreateTable.sql a InsertData.sql.
V souboru CreateDatabase.sql je potřeba zeditovat následující řádky:

( NAME = N'TestAlzaRestApiDatabase', FILENAME = N'D:\SQL\Data\TestAlzaRestApiDatabase.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'TestAlzaRestApiDatabase_log', FILENAME = N'D:\SQL\Data\TestAlzaRestApiDatabase_log.ldf' , SIZE = 4096KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)

a to název databáze a místo na disku, kde se má vytvořit.
Pak následně jeden po druhém spustit.

Následně pak ještě upravit connection string v souboru  TestAlzaRestApi/TestAlzaRestApi/appsettings.json
