USE [AdminSemi]
GO

INSERT INTO [dbo].[Inquilinos](
          [Codigo],[Nombre],[DNI],[Telefono],[Domicilio],[Localidad],[UltimoAlquiler],[TelUltAlquiler],[Trabajo],[TelTrabajo],[DomTrabajo],[Estado],[DescEstado],[TipoIva],         [Cuit],   [Observaciones],[Cuenta],[Usuario],[FechaMod],[AgRetGan],[DocPend],[InqEMail])     
SELECT   Locatario, trim(Nombre), 0, trim(telfijo), trim(Domicilio),       trim(Localidad),       null,                null,    trim(trabajo),   trim(teltrabajo),       null,    'A',         NULL,       'RIN', isnull(CAST(nro_docuit as varchar(15)), 0),  null,        null,     'sa', getdate(),    0,        0 ,  null
FROM adminSemiImp..[Locatarios]
WHERE cod_doc = '01'
INSERT INTO [dbo].[Inquilinos](
          [Codigo],[Nombre],[DNI],              [Telefono],[Domicilio],[Localidad],[UltimoAlquiler],[TelUltAlquiler],[Trabajo],[TelTrabajo],[DomTrabajo],[Estado],[DescEstado],[TipoIva],[Cuit],[Observaciones],[Cuenta],[Usuario],[FechaMod],[AgRetGan],[DocPend],[InqEMail])     
SELECT   Locatario, trim(Nombre), isnull(nro_docuit, 0), trim(telfijo), trim(Domicilio), trim(Localidad),       null,                null, trim(trabajo),   trim(teltrabajo),       null,    'A',         NULL,       'CFI',      0,      null,          null,     'sa', getdate(),    0,        0 ,  null
FROM adminSemiImp..[Locatarios]
WHERE cod_doc = '02'
