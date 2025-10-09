using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using MyAquariumManager.Core.Helpers;

namespace MyAquariumManager.Tests.Unit.Core.Helpers
{
    public class ValidadorDeDocumentosHelperTests
    {
        [Theory]
        [InlineData("567.042.810-29", true)]
        [InlineData("56704281029", true)]
        [InlineData("25884525079", true)]
        [InlineData("000.000.000-00", false)]
        [InlineData("111.111.111-11", false)]
        [InlineData("123.456.789-01", false)]
        [InlineData("12345", false)]
        [InlineData(null, false)]
        [InlineData("", false)]
        [InlineData("abc.def.ghi-jk", false)]
        [InlineData("73.298.712/0001-02", false)]
        public void AoValidarUmCpf_DeveRetornarResultadoCorreto(string cpf, bool esperado) 
        {
            //Act
            bool resultado = ValidadorDeDocumentosHelper.EhUmCpfValido(cpf);

            //Assert
            Assert.Equal(esperado, resultado);
        }

        [Theory]
        [InlineData("12.ABC.345/01DE-35", true)]
        [InlineData("12ABC34501DE35", true)]
        [InlineData("73.298.712/0001-02", true)]
        [InlineData("74764064000103", true)]
        [InlineData("12.ABC.345/01DE-37", false)]
        [InlineData("12ABC34501DE37", false)]
        [InlineData("12.XXX.345/01XX-37", false)]
        [InlineData("XX.XXX.XXX/XXXX-XX", false)]
        [InlineData("00.000.000/0000-00", false)]
        [InlineData("11111111111111", false)]
        [InlineData("11.222.333/0001-82", false)]
        [InlineData("1234567890123", false)]
        [InlineData("567.042.810-29", false)]
        [InlineData("bg.hjj.asd/asec-da", false)]
        [InlineData(null, false)]
        [InlineData("", false)]
        public void AoValidarUmCnpj_DeveRetornarResultadoCorreto(string cnpj, bool esperado)
        { 
            //Act
            bool resultado = ValidadorDeDocumentosHelper.EhUmCnpjValido(cnpj);

            //Assert
            Assert.Equal(esperado, resultado);
        }

        [Theory]
        [InlineData("73.298.712/0001-02", true)]
        [InlineData("74764064000103", true)]
        [InlineData("567.042.810-29", true)]
        [InlineData("56704281029", true)]
        [InlineData("00.000.000/0000-00", false)]
        [InlineData("11111111111111", false)]
        [InlineData("000.000.000-00", false)]
        [InlineData("111.111.111-11", false)]
        [InlineData("11.222.333/0001-82", false)]
        [InlineData("123.456.789-01", false)]
        [InlineData("asce", false)]
        [InlineData("123", false)]
        [InlineData(null, false)]
        [InlineData("", false)]
        public void AoValidarUmDocumento_DeveRetornarResultadoCorreto(string documento, bool esperado)
        {
            //Act
            bool resultado = ValidadorDeDocumentosHelper.EhUmDocumentoValido(documento);

            //Assert
            Assert.Equal(esperado, resultado);
        }
    }
}
