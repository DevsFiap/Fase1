﻿using System.ComponentModel.DataAnnotations;
using TechChallangeFase01.Domain.Entities;
using TechChallangeFase01.Domain.Enums;

namespace TechChallangeFase01.Application.Dto;

public class CriarContatoDto
{
    [Required(ErrorMessage = "O nome é obrigatório.")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O telefone é obrigatório.")]
    [RegularExpression(@"^\d{10,11}$", ErrorMessage = "O telefone deve ter entre 10 e 11 dígitos, sem formatação.")]
    public string Telefone { get; set; }

    [EmailAddress(ErrorMessage = "E-mail inválido.")]
    public string Email { get; set; }

    public string TelefoneFormatado => TelefoneFormatter.FormatarTelefone(Telefone);

    public Contato ConverterParaContato()
    {
        // Separar DDD e número
        var ddd = Telefone.Substring(0, 2);
        var numeroTelefone = Telefone.Substring(2);

        return new Contato
        {
            Nome = Nome,
            Telefone = numeroTelefone, // Armazena apenas o número
            DDDTelefone = (EnumDDD)int.Parse(ddd), // Armazena o DDD
            Email = Email,
            DataCriacao = DateTime.Now
        };
    }
}