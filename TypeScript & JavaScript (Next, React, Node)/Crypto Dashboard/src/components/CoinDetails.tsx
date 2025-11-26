import React, { useState, useEffect } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import {
  LineChart, Line, XAxis, YAxis, CartesianGrid, Tooltip, ResponsiveContainer
} from 'recharts';
import Header from './Header';
import Footer from './Footer';

// Utility for currency symbols
const getCurrencySymbol = (code: string) => {
  const symbols: Record<string, string> = {
    usd: '$',
    eur: '€',
    gbp: '£',
    zar: 'R',
    aud: 'A$',
    cad: 'C$',
    chf: 'CHF',
    cny: '¥',
  };
  return symbols[code.toLowerCase()] || code.toUpperCase();
};

const CoinDetails: React.FC = () => {
  const navigate = useNavigate();
  const { coinId } = useParams<{ coinId: string }>();
  const [currency, setCurrency] = useState('zar');
  const [coin, setCoin] = useState<any>(null);
  const [chart, setChart] = useState<any[]>([]);
  const [loadingCoin, setLoadingCoin] = useState(false);
  const [loadingChart, setLoadingChart] = useState(false);
  const [apiKey, setApiKey] = useState('');
  const [error, setError] = useState<string | null>(null);

  // Get its own API key since not passing ChartData from App anymore
  useEffect(() => {
    const fetchKey = async () => {
      try {
        const baseUrl = process.env.NODE_ENV === 'development'
          ? 'http://localhost:5000'
          : '';
        const res = await fetch(`${baseUrl}/api/CoinGecko`);
        if (!res.ok) throw new Error('Failed to fetch key');
        const data = await res.json();
        setApiKey(data.key);
      } catch (err) {
        console.error('API key fetch error:', err);
      }
    };
    fetchKey();
  }, []);

  // Fetch coin details, updates with currency change
  useEffect(() => {
    if (!coinId || !apiKey) return;

    const fetchCoin = async (): Promise<void> => {
      try {
        setLoadingCoin(true);
        setError(null);                     // clear previous error

        const res = await fetch(
          `https://api.coingecko.com/api/v3/coins/markets?vs_currency=${currency}&ids=${coinId}`,
          { headers: { 'x-cg-demo-api-key': apiKey } }
        );

        if (res.status === 429) {           // rate-limit
          setError('Too many requests – waiting 2 s…');
          await new Promise(r => setTimeout(r, 2000));
          return fetchCoin();               // try once more
        }

        const data = await res.json();
        if (data?.length > 0) setCoin(data[0]);
      } catch (err) {
        setError('Failed to load price. Try again.');
      } finally {
        setLoadingCoin(false);
      }
    };

    fetchCoin();
  }, [coinId, currency, apiKey]);   // ← keep apiKey in deps

  // Fetch chart data, updates when currency changes. CoinGecko API doesn't always respond with 10 requests at once
  useEffect(() => {
    if (!coinId || !apiKey) return;

    const fetchChart = async (): Promise<void> => {
      try {
        setLoadingChart(true);
        setError(null);

        const res = await fetch(
          `https://api.coingecko.com/api/v3/coins/${coinId}/market_chart?vs_currency=${currency}&days=7`,
          { headers: { 'x-cg-demo-api-key': apiKey } }
        );

        if (res.status === 429) {
          setError('Chart loading slowly – waiting…');
          await new Promise(r => setTimeout(r, 2000));
          return fetchChart();
        }

        const data = await res.json();
        const formatted = data.prices.map((p: any[]) => ({
          date: new Date(p[0]).toLocaleDateString(),
          price: p[1],
        }));
        setChart(formatted);
      } catch (err) {
        setError('Chart failed. Try again.');
      } finally {
        setLoadingChart(false);
      }
    };

    fetchChart();
  }, [coinId, currency, apiKey]);   // ← keep apiKey in deps

  const symbol = getCurrencySymbol(currency);

  if (!coin && !loadingCoin) {
    return (
      <div className="App">
        <Header currency={currency} setCurrency={setCurrency} />
        <div className="not-available">
          <p>Coin details not available.</p>
          <p>Did you overuse the API?</p>
          <button className="back-button" onClick={() => navigate('/')}>Go Back</button>
        </div>
        <Footer />
      </div>
    );
  }

  return (
    <div className="App coin-details">
      <Header currency={currency} setCurrency={setCurrency} />

      {error && (
        <div style={{
          color: '#d97706',
          background: '#fffbeb',
          padding: '8px 12px',
          borderRadius: '6px',
          margin: '10px 0',
          border: '1px solid #fde68a',
        }}>
          <p>You've likely hit an API rate limit. Please wait before trying again. Data below may be incorrect. Error: {error}</p>
        </div>
      )}

      <div>
        <button className="back-button" onClick={() => navigate('/')}>
          Back to dashboard
        </button>
      </div>

      {loadingCoin ? (
        <p>Loading coin data...</p>
      ) : (
        <>
          <div>
            <img src={coin.image} alt={coin.name} width={64} height={64} />
            <h2>{coin.name} ({coin.symbol.toUpperCase()})</h2>
            <h3>Market Cap Rank {coin.market_cap_rank}</h3>
          </div>
          <div className="columns">
            <div className="left-column">
              <p><b>Market Cap:</b> {symbol}{coin.market_cap.toLocaleString(undefined, { maximumFractionDigits: 2 })}</p>
              <p><b>Current Price:</b> {symbol}{coin.current_price.toLocaleString(undefined, { maximumFractionDigits: 2 })}</p>
              <p><b>24h Volume:</b> {symbol}{coin.total_volume.toLocaleString(undefined, { maximumFractionDigits: 2 })}</p>
              <p><b>24h High:</b> {symbol}{coin.high_24h.toLocaleString(undefined, { maximumFractionDigits: 2 })}</p>
              <p><b>24h Low:</b> {symbol}{coin.low_24h.toLocaleString(undefined, { maximumFractionDigits: 2 })}</p>
              <p><b>Price Change (24h):</b> {symbol}{coin.price_change_24h.toLocaleString(undefined, { maximumFractionDigits: 2 })}</p>
              <p><b>Price Change Percentage (24h):</b> {coin.price_change_percentage_24h.toFixed(2)}%</p>
              <p><b>Last Updated:</b> {new Date(coin.last_updated).toLocaleString()}</p>
            </div>

            <div className="right-column">
              <p><b>Circulating Supply:</b> {coin.circulating_supply.toLocaleString()}</p>
              <p><b>Total Supply:</b> {coin.total_supply ? coin.total_supply.toLocaleString() : 'N/A'}</p>
              <p><b>Max Supply:</b> {coin.max_supply ? coin.max_supply.toLocaleString() : 'N/A'}</p>
              <p><b>Fully Diluted Valuation:</b> {symbol}{coin.fully_diluted_valuation?.toLocaleString(undefined, { maximumFractionDigits: 2 }) || 'N/A'}</p>
              <p><b>ATH:</b> {symbol}{coin.ath.toLocaleString(undefined, { maximumFractionDigits: 2 })}</p>
              <p><b>ATH Change Percentage:</b> {coin.ath_change_percentage.toFixed(2)}%</p>
              <p><b>ATL:</b> {symbol}{coin.atl.toLocaleString(undefined, { maximumFractionDigits: 2 })}</p>
              <p><b>ATL Change Percentage:</b> {coin.atl_change_percentage.toFixed(2)}%</p>
            </div>
          </div>
        </>
      )}

      <h2>Chart - Last 7 Days</h2>

      {loadingChart ? (
        <p>Loading chart...</p>
      ) : chart && chart.length > 0 ? (
        <div className="chart-container">
          <ResponsiveContainer className="page-chart" width="100%" height={300}>
            <LineChart data={chart} margin={{ top: 20, right: 30, left: 20, bottom: 40 }}>
              <CartesianGrid strokeDasharray="3 3" />
              <XAxis label={{ 
                  value: 'Date',
                  position: 'bottom',
                  style: { textAnchor: 'middle' },
                  offset: 0
                }}  
                dataKey="date" tick={{ fontSize: 12 }} />
              <YAxis label={{ 
                  value: 'Price', 
                  angle: -90, 
                  position: 'insideLeft',
                  style: { textAnchor: 'middle' },
                  offset: -2
                }}  
                tick={{ fontSize: 12 }} />
              <Tooltip
                contentStyle={{
                  backgroundColor: '#1f2937',
                  border: '1px solid #374151',
                  borderRadius: '8px',
                  color: '#f9fafb',
                  fontSize: '12px',
                  boxShadow: '0 2px 6px rgba(0,0,0,0.3)'
                }}
                labelStyle={{ color: '#93c5fd', fontWeight: 'bold' }}
                itemStyle={{ color: '#a5b4fc', textTransform: 'capitalize' }}
                formatter={(value: number) => `${symbol}${value.toFixed(2)}`}
              />
              <Line type="monotone" dataKey="price" stroke="#8884d8" dot={false} />
            </LineChart>
          </ResponsiveContainer>
        </div>
      ) : (
        <p>Chart data not available.</p>
      )}

      <Footer />
    </div>
  );
};

export default CoinDetails;
