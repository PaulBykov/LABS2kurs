import React from 'react';

import Footer from "../../widgets/footer/Footer";
import Header from "../../widgets/header/Header";
import MovieCatalog from "../../widgets/movie/MovieCatalog/ui/MovieCatalog";

function HomePage() {
    return (
        <>
            <Header/>
                <MovieCatalog/>
            <Footer/>
        </>
    );
}

export default HomePage;