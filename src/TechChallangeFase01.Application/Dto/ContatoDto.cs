﻿using System.Text.Json.Serialization;
using TechChallangeFase01.Domain.Enums;

namespace TechChallangeFase01.Application.Dto;

public class ContatoDto
{
    public string? Nome { get; set; }
    public string? Email { get; set; }
    public EnumDDD DDDTelefone { get; set; }
    public string? NumeroTelefone { get; set; }
    public DateTime DataCriacao { get; set; }

    [JsonIgnore]
    public string TelefoneFormatado => TelefoneFormatter.FormatarTelefone(NumeroTelefone);

    public void SepararTelefone(string telefoneCompleto)
    {
        if (telefoneCompleto == null)
            throw new ArgumentNullException(nameof(telefoneCompleto));

        DDDTelefone = (EnumDDD)int.Parse(telefoneCompleto.Substring(0, 2));
        NumeroTelefone = telefoneCompleto.Substring(2);
    }
}