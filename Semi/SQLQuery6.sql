use adminsemi
update propiedades set localidad = (SELECT nombre from adminsemiimp..localidades where Localidad = propiedades.Localidad) 
