select
ve.Renavam,
ma.Nome Marca,
mo.Descricao Modelo,
mo.AnoModelo,
mo.AnoFabricacao,
ve.Quilometragem,
ve.Valor,
CONCAT(proEnd.Cidade,' - ', proEnd.Estado) ,
(case when ve.Status = 0 then 'Indisponível' 
	  when ve.Status = 1 then 'Disponível'
	  when ve.Status = 99 then 'Vendido' end) Status,
convert(varchar(20),ve.DataCadastro,103)+' '+convert(varchar(20),convert(time,ve.DataCadastro),108) DataCadastro,
convert(varchar(20),ve.DataAlteracao,103)+' '+convert(varchar(20),convert(time,ve.DataAlteracao),108) DataAlteracao
from Automobile.dbo.veiculos ve
inner join Automobile.dbo.Modelos mo on ve.Id = mo.VeiculoId
inner join Automobile.dbo.Marcas ma on ve.MarcaId = ma.Id
inner join Automobile.dbo.Proprietarios pro on ve.ProprietarioId = pro.Id
left join Automobile.dbo.ProprietarioEnderecos proEnd on pro.Id = proEnd.ProprietarioId
 