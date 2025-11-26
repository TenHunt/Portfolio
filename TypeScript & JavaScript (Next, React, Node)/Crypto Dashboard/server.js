require('dotenv').config();
const express = require('express');
const cors = require('cors');
const app = express();

app.use(cors()); // Only needed so React can call it

app.get('/api/CoinGecko', (req, res) => {
  res.json({ key: process.env.COINGECKO_API_KEY });
});

app.listen(5000, () => {
  console.log('Key:', process.env.COINGECKO_API_KEY);
  console.log('Server on http://localhost:5000');
});