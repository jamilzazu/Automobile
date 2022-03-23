﻿using Automobile.Core.Messages;
using FluentValidation;
using System;

namespace Automobile.Proprietarios.API.Application.Commands
{
    public class RegistrarEnderecoCommand : Command
    {
        public Guid Id { get; private set; }
        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Bairro { get; private set; }
        public string Cep { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public Guid ProprietarioId { get; private set; }

        public RegistrarEnderecoCommand(Guid id, string logradouro, string numero, string complemento, string bairro, string cep, string cidade, string estado)
        {
            AggregateId = id;
            Id = id;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cep = cep;
            Cidade = cidade;
            Estado = estado;
        }


        public override bool EhValido()
        {
            ValidationResult = new RegistrarEnderecoValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class RegistrarEnderecoValidation : AbstractValidator<RegistrarEnderecoCommand>
    {
        public RegistrarEnderecoValidation()
        {
            RuleFor(c => c.ProprietarioId)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do proprietário inválido");

            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do endereço inválido");

            RuleFor(c => c.Logradouro)
                .NotEmpty()
                .WithMessage("O logradouro do endereço não foi informado");

            RuleFor(c => c.Numero)
                .NotEmpty()
                .WithMessage("O número do endereço não foi informado");

            RuleFor(c => c.Bairro)
                .NotEmpty()
                .WithMessage("O bairro do endereço não foi informado");

            RuleFor(c => c.Cep)
                .NotEmpty()
                .WithMessage("O cep do endereço não foi informado");

            RuleFor(c => c.Cidade)
                .NotEmpty()
                .WithMessage("O cidade do endereço não foi informado");

            RuleFor(c => c.Estado)
                .NotEmpty()
                .WithMessage("O estado do endereço não foi informado");
        }
    }
}
