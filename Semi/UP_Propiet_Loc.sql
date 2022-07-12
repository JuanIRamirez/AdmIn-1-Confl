use adminsemi
update propietarios set LocalidadId = (select LocalidadId from Localidad where Descrip=propietarios.Localidad)