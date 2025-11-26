import React from 'react';
// import { LineChart, Line, XAxis, YAxis, CartesianGrid, Tooltip, ResponsiveContainer } from 'recharts';

interface CoinChartProps {
  name: string;
  image: string;
  marketCap: number;
  volume: number;
  //chartData: { date: string; price: number }[];
  currentPrice: number,
  currency: string;
  onClick: () => void; // click handler passed from App
}

const getCurrencySymbol = (code: string) => {
  const symbols: Record<string, string> = {
    usd: '$',
    eur: '€',
    gbp: '£',
    zar: 'R',
    aud: 'A$',
    cad: 'C$',
    chf: 'CHF',
    cny: '¥'
  };
  return symbols[code.toLowerCase()] || code.toUpperCase();
};

const CoinChart: React.FC<CoinChartProps> = ({
  name,
  image,
  marketCap,
  volume,
  //chartData,
  currentPrice,
  currency,
  onClick
}) => {
  const symbol = getCurrencySymbol(currency);

  return (
    <div 
      className="coin-card"
      onClick={onClick} 
      style={{ cursor: 'pointer' }}
    >
      <div className="coin-header">
        <img src={image} alt={name} width={32} height={32} />
        <h2>{name}</h2>
      </div>
      <div>
        <p>Current Price: {symbol}{currentPrice.toLocaleString(undefined, { minimumFractionDigits: 2, maximumFractionDigits: 2 })}</p>
        <p>Market Cap: {symbol}{marketCap.toLocaleString()}</p>
        <p>24hr Volume: {symbol}{volume.toLocaleString()}</p>
      </div>

      {/*chartData.length > 0 ? (
        <ResponsiveContainer width="100%" height={200}>
          <LineChart data={chartData}>
            <CartesianGrid strokeDasharray="3 3" />
            <XAxis dataKey="date" tick={{ fontSize: 10 }} />
            <YAxis tick={{ fontSize: 10 }} />
            <Tooltip
              contentStyle={{
                backgroundColor: '#1f2937',
                border: '1px solid #374151',
                borderRadius: '8px',
                color: '#f9fafb',
                fontSize: '12px',
                boxShadow: '0 2px 6px rgba(0,0,0,0.3)'
              }}
              labelStyle={{ color: '#93c5fd', fontWeight: 'bold' }} // Date label
              itemStyle={{ color: '#a5b4fc', textTransform: 'capitalize' }} // Price label text
              formatter={(value: number) => `${symbol}${value.toFixed(2)}`} // Price number
            />
            <Line type="monotone" dataKey="price" stroke="#8884d8" dot={false} />
          </LineChart>
        </ResponsiveContainer>
      ) : (
        <p>Chart data not available yet.</p>
      )*/}
      <p className="details-button">Coin Details & Chart</p>
    </div>
  );
};

export default CoinChart;
