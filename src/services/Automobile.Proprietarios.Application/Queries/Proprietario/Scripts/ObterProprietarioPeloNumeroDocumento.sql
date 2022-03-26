select
      Id,
      Nome,
      Email,
      TipoDocumento,
      Documento,
      Cancelado,
      DataCadastro,
      DataAlteracao
from Automobile.dbo.proprietarios
where Documento = @numeroDocumento