select
      Id,
      Nome,
      Email,
      (case when TipoDocumento = 0 then 'CNPJ' when TipoDocumento = 1 then 'CPF' end) TipoDocumento,
      NumeroDocumento,
      (case when Cancelado = 0 then 'Não' when Cancelado = 1 then 'Sim' end) Cancelado,
      convert(varchar(20),DataCadastro,103)+' '+convert(varchar(20),convert(time,DataCadastro),108) DataCadastro,
      convert(varchar(20),DataAlteracao,103)+' '+convert(varchar(20),convert(time,DataAlteracao),108) DataAlteracao
from Automobile.dbo.proprietarios
where id = id