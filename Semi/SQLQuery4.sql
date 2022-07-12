USE [AdminSemi]
GO

INSERT INTO [dbo].[Propiedades]([Propietario],[Codigo],[Inquilino],[Valor],                                                  [Domicilio], [Barrio],[Localidad],[Tipo],[Descripcion],[Estado],[TipoAlq],[NomCat],[Comision],[Usuario],[FechaMod])
     SELECT                     [Propietario],[Codigo],     0 ,   [precio],trim([Domicilio])+ isnull(', P.' + trim([Piso]),'') + isnull(', Dto.' + trim([Dpto]),''), '' ,[Localidad],  ''  ,trim([descripcion]),     'A',      'P',      '',      null,    'sa', getdate()
  FROM adminsemiimp..Inmuebles
GO
