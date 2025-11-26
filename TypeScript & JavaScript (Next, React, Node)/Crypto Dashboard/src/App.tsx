import { useState, useEffect } from 'react';
import axios from 'axios';
import './App.css';
import CoinCard from './components/CoinCard';
import CoinDetails from './components/CoinDetails';
import { BrowserRouter as Router, Routes, Route, useNavigate } from 'react-router-dom';
import Header from './components/Header';
import Footer from './components/Footer';

function MainApp() {
  const [apiKey, setApiKey] = useState('');
  const [coinData, setCoinData] = useState<any[]>([]);
  //const [chartData, setChartData] = useState<any[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);
  const [currency, setCurrency] = useState('zar'); // Default currency must be ZAR
  const navigate = useNavigate();

  // Get API key from backend, run `node server.js` before app locally, Vercel uses API route
  useEffect(() => {
    const fetchKey = async () => {
      try {
        // Use localhost in development, otherwise use relative path
        const baseUrl =
          process.env.NODE_ENV === 'development'
            ? 'http://localhost:5000'
            : '';

        const res = await fetch(`${baseUrl}/api/CoinGecko`);
        if (!res.ok) throw new Error(`HTTP error! Status: ${res.status}`);

        const data = await res.json();
        setApiKey(data.key);
      } catch (err) {
        console.error('API key fetch error:', err);
      }
    };

    fetchKey();
  }, []);


  // Fetch top 10 coins
  useEffect(() => {
    if (!apiKey) return;

    const fetchCoins = async () => {
      try {
        setLoading(true);
        const response = await axios.get(
          'https://api.coingecko.com/api/v3/coins/markets',
          {
            params: {
              vs_currency: currency,
              order: 'market_cap_desc',
              per_page: 10,
              page: 1,
            },
            headers: { 'x-cg-demo-api-key': apiKey },
          }
        );
        setCoinData(response.data);
      } catch (err: any) {
        setError(err.message);
      } finally {
        setLoading(false);
      }
    };

    fetchCoins();
  }, [apiKey, currency]);

  /*
  // Fetch chart data for each coin
  useEffect(() => {
    if (!coinData.length || !apiKey) return;

    const fetchCharts = async () => {
      setLoading(true);
      const allChartData: { id: string; data: { date: string; price: number }[] }[] = [];

      for (const coin of coinData) {
        try {
          const response = await axios.get(
            `https://api.coingecko.com/api/v3/coins/${coin.id}/market_chart`,
            {
              params: { vs_currency: currency, days: 7 },
              headers: { 'x-cg-demo-api-key': apiKey },
            }
          );
          const formattedData = response.data.prices.map((price: any[]) => ({
            date: new Date(price[0]).toLocaleDateString(),
            price: price[1],
          }));
          allChartData.push({ id: coin.id, data: formattedData });
          await new Promise(res => setTimeout(res, 200)); // Small delay for API limits
        } catch (err) {
          console.error(`Error loading chart for ${coin.id}`, err);
        }
      }

      setChartData(allChartData);
      setLoading(false);
    };

    fetchCharts();
  }, [coinData, apiKey, currency]);
  */

  // Handle card click
  const handleCardClick = (coin: any) => {
    //const chart = chartData.find(c => c.id === coin.id)?.data || [];
    navigate(`/coin/${coin.id}`, { state: { coin } });
  };

  // Main dashboard
  return (
    <div className="App">
      <Header currency={currency} setCurrency={setCurrency} />
      {error && <p style={{ color: 'red' }}>Error: {error}</p>}

      <div className="content-wrapper">
        {loading && <div className="loading-overlay"><b>Loading...</b></div>}
        <div className="coin-grid">
          {coinData.map(coin => (
            <CoinCard
              key={coin.id}
              name={coin.name}
              image={coin.image}
              marketCap={coin.market_cap}
              volume={coin.total_volume}
              currentPrice={coin.current_price}
              currency={currency}
              onClick={() => handleCardClick(coin)} // User can click anywhere on the card
            />
          ))}
        </div>
      </div>
      <Footer />
    </div>
  );
}

// Proper routing, now each coin has its own page
function App() {
  return (
    <Router>
      <div className="App">
        <Routes>
          <Route path="/" element={<MainApp />} />
          <Route path="/coin/:coinId" element={<CoinDetails />} />
        </Routes>
      </div>
    </Router>
  );
}

export default App;