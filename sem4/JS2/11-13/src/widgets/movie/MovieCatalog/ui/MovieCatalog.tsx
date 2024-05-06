import React, {SetStateAction, useEffect, useState} from 'react';

import {getMovies} from "../api/getMovies";
import {IMovie} from "../../MovieCard/MovieCard";
import MovieList from "../../MovieList/MovieList";

import Search from "../../../../feateures/search/Search";
import Filter, {MovieType} from "../../../../feateures/filter/Filter";

interface MovieCatalogProps {
    MType: MovieType;
}
function MovieCatalog(props: MovieCatalogProps) {
    const [movies, setMovies] = useState<IMovie[]>([]);
    const [title, setTitle] :[string, React.Dispatch<SetStateAction<string>>] = useState("john wick");
    const [type, setType] = useState<MovieType>(props.MType);

    const fetchMovies = async (_title: string, _type: MovieType) => {
        const response :IMovie[] = await getMovies(_title, _type);
        setMovies(response);
    }

    useEffect(() => {
        fetchMovies(title, type)
    }, [title, type]);

    return (
        <>
            <Search setTitle={setTitle}/>
            <Filter setType={setType}/>
            <MovieList movies={movies} />
        </>
    );
}

export default MovieCatalog;