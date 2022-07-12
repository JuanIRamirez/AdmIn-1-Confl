USE [AdminSemi]
GO

INSERT INTO [dbo].[Propietarios](
            [Codigo],[Dni],[Nombre],           [Barrio],      [Domicilio],      [Localidad],      [Telefono], [Tel_Emp],            [Tel_Movil],      [eMail],     [CUIT],[Empresa],[DomEmp],[emailEmp],[Condicion],[LocEmp],[TipoIva],[TipoFactura],[FormaPago],[CatGcias],[Comision],[Cuenta],[CtaAdl],[Observaciones],[Banco],[TipoCta],[NroCta],[NombreCta],[CBU],[Usuario],[FechaMod],[Estado],[Legajo],[DocPend],[FechaNac],[AlicGan],[LocalidadId])
     SELECT [Codigo],    0, trim(nombre),  trim(barrio),  trim(domicilio),  trim(localidad),  trim(telefono),   null, trim(tm_car)+trim(tm_nro),  trim(email), isnull(nro_docuit,0),    null,     null,      null,      1    ,   0    ,    'RIN',         null,       '',      0   , Comision,       '',     '' ,           null,    0  ,     '',       '',      '',     '',      'sa', getdate(),    'A',       '' ,     null,     null,           0,           0  
  FROM AdminSemiImp..Propietarios
  where cod_doc = '01'
GO
INSERT INTO [dbo].[Propietarios](
            [Codigo],[Dni],         [Nombre],		[Barrio],		[Domicilio],	[Localidad],		[Telefono],			[Tel_Emp],[Tel_Movil],	       [eMail],[CUIT],[Empresa],[DomEmp],  [emailEmp],[Condicion],[LocEmp],[TipoIva],[TipoFactura],[FormaPago],[CatGcias],[Comision],[Cuenta],[CtaAdl],[Observaciones],[Banco],[TipoCta],[NroCta],[NombreCta],[CBU],[Usuario],[FechaMod],[Estado],[Legajo],[DocPend],[FechaNac],[AlicGan],[LocalidadId])
     SELECT [Codigo],isnull(nro_docuit,0), trim(nombre),  trim(barrio),  trim(domicilio),  trim(localidad),  trim(telefono),   null, trim(tm_car)+trim(tm_nro),  trim(email),    0,       null,     null,      null,      1    ,   0    ,    'CFI',        null,       '',      0   , Comision,   '',     '' ,           null,    0  ,     '',       '',      '',     '',      'sa', getdate(),    'A',       '' , null,     null, 0, 0  
  FROM AdminSemiImp..Propietarios
  where cod_doc = '02'
GO

UPDATE Propietarios SET ComFija = 1 where Comision > 99


