# Daniël De Jager's Crypto Dashboard

Welcome to my cryptocurrency dashboard that lists the top 10 cryptocurrencies and provides more information for each coin when selected. You can also view prices in different currencies.

## Access the app live on Vercel

Visit the app [here on Vercel](https://octoco-3awga5ulg-daniels-projects-8622db1d.vercel.app/).

## Setting up and running the app locally

In the project directory, install the required packages:

`npm install axios recharts express dotenv cors react-router-dom`

Run the server (built for security purposes) to be able to request the API key:

`node server.js`

The API key for the .env file in the root folder must be obtained from me, or you can use your own CoinGecko API key using the .env.example.

Run the app in the development mode:

`npm start`

Open [http://localhost:3000](http://localhost:3000) to view it in the browser.

## Notes

Thanks to [CoinGecko](https://coingecko.com) for their API and data.\
**CoinGecko's Demo API is very finicky in terms of overuse, do not exceed 30 requests per minute.**
