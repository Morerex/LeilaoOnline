using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Alura.LeilaoOnline.Core;
using System.Linq;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoRecebeOferta
    {

        [Fact]
        public void NaoAceitaProximoLanceDadoMesmoClienteRealizouUltimoLance()
        {
            //Arranje - cenário
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);

            leilao.IniciaPregao();

            leilao.RecebeLance(fulano, 800);

            //Act - Método sob teste
            leilao.RecebeLance(fulano,1000);


            //Assert
            var qtdEsperada = 1;
            var qtdeObtido = leilao.Lances.Count();

            Assert.Equal(qtdEsperada, qtdeObtido);
        }


        [Theory]
        [InlineData(4,new double[] {1000,1200,1400,1600})]
        [InlineData(2, new double[] { 800, 900 })]
        public void NaoPermiteNovosLancesDadoLeilaoFinalizado(int qtdeEsperada, double[] ofertas)
        {
            //Arranje - cenário
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            var maria = new Interessada("Maria", leilao);

            leilao.IniciaPregao();
            for (int i = 0; i < ofertas.Length; i++)
            {
                var valor = ofertas[i];
                if ((i % 2) == 0)
                {
                    leilao.RecebeLance(fulano, valor);
                }
                else
                {
                    leilao.RecebeLance(maria, valor);

                }
            }
            leilao.TerminaPregao();

            //Act - Método sob teste
            leilao.RecebeLance(fulano, 1000);

            //Assert
            var qtdeObtido = leilao.Lances.Count();

            Assert.Equal(qtdeEsperada, qtdeObtido);
        }
    }
}
