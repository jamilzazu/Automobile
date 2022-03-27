select
      Id,
      Nome,
      Email,
      TipoDocumento,
      NumeroDocumento,
      Cancelado,
      DataCadastro,
      DataAlteracao
from Automobile.dbo.proprietarios
where NumeroDocumento = @numeroDocumento