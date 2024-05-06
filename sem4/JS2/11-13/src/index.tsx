import React from 'react';
import ReactDOM from 'react-dom/client';
import {BrowserRouter, Route, Routes} from "react-router-dom";

import './app/index/index.css';

import HomePage from "./pages/home/HomePage";
import MoviePage from "./pages/movie/MoviePage";

const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement
);

root.render(
  <React.StrictMode>
    <BrowserRouter>
        <Routes>
            <Route path="/" element={<HomePage/>}/>
            <Route path="/home" element={<HomePage/>}/>
            <Route path="/movie/:id" element={<MoviePage/>}/>

            <Route path="/home/:type" element={<HomePage/>}/>
        </Routes>
    </BrowserRouter>
  </React.StrictMode>
);
