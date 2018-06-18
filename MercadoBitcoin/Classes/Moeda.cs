using System;

namespace MercadoBitcoin.Classes
{
    class Moeda
    {

        private readonly Tipo _tipo;
        public Dados Dados;
        public DadosBitfinex DadosBitfinex;

        public enum Tipo
        {
            Bitcoin,
            BitcoinCash,
            Litecoin,
            IotBtc,
            IotUsd,
            DshBtc,
            DshUsd,
            GntBtc,
            GntUsd
        };

        public Moeda(Tipo tipo)
        {
            _tipo = tipo;
            Dados = new Dados(GetTipoString());
            DadosBitfinex = new DadosBitfinex(GetTipoString());
        }
        
        public String GetTipoString()
        {
            if (_tipo == Tipo.Bitcoin)
                return "BTC";
            if (_tipo == Tipo.BitcoinCash)
                return "BCH";
            if (_tipo == Tipo.Litecoin)
                return "LTC";
            if (_tipo == Tipo.IotBtc)
                return "tIOTBTC";
            if (_tipo == Tipo.IotUsd)
                return "tIOTUSD";
            if (_tipo == Tipo.DshBtc)
                return "tDSHBTC";
            if (_tipo == Tipo.DshUsd)
                return "tDSHUSD";
            if (_tipo == Tipo.GntBtc)
                return "tGNTBTC";
            if (_tipo == Tipo.GntUsd)
                return "tGNTUSD";

            return "";
        }

    }
}
