import React from 'react';

interface HeaderProps {
  currency: string;
  setCurrency: (newCurrency: string) => void;
}

const Header: React.FC<HeaderProps> = ({ currency, setCurrency }) => {
  return (
    <header className="header">
      <h1 className="header-title">Crypto Dashboard</h1>
      <p className="header-description">Track prices and market data for the top 10 cryptocurrencies</p>
      <div className="currency">
        <label className="currencyLabel" htmlFor="currencyPicker">Select Currency:</label>
        <select className="currencyPicker" value={currency} onChange={(e) => setCurrency(e.target.value)}>
          <option value="zar">ZAR</option>
          <option value="usd">USD</option>
          <option value="eur">EUR</option>
          <option value="gbp">GBP</option>
          <option value="aud">AUD</option>
          <option value="cad">CAD</option>
          <option value="chf">CHF</option>
          <option value="cny">CNY</option>
        </select>
      </div>
    </header>
  );
};

export default Header;