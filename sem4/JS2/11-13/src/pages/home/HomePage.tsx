import React from 'react';

import Footer from "../../widgets/footer/Footer";
import Header from "../../widgets/header/Header";
import MovieCatalog from "../../widgets/movie/MovieCatalog/ui/MovieCatalog";
import {useParams} from "react-router-dom";
import {MovieType} from "../../feateures/filter/Filter";

function convertStringToMovieType(value: string) {
    if(value as MovieType){
        return value as MovieType;
    }

    throw new Error();
}

function HomePage() {
    let {type} = useParams();
    if(type === undefined) type = "any";
    const MType = convertStringToMovieType(type);

    return (
        <>
            <Header/>
            <MovieCatalog MType={MType}/>
            <Footer/>
        </>
    );
}

export default HomePage;