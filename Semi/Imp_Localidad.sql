USE [AdminSemi]
GO

INSERT INTO [dbo].[Localidad]
           ([Codigo]
           ,[Descrip]
           ,[Provincia]
           ,[Pais]
           ,[Usuario]
           ,[FechaMod])
     SELECT isnull([CodPostal],0)
	  ,trim([Nombre])
      ,[Provincia]
      , 1
	  , 'sa'
	  , getdate()
  FROM AdminSemiImp..Localidades


