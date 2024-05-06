import React, {SetStateAction, useEffect, useState} from 'react';

import {getMovies} from "../api/getMovies";
import {IMovie} from "../../MovieCard/MovieCard";
import MovieList from "../../MovieList/MovieList";

import Search from "../../../../feateures/search/Search";

function MovieCatalog() {
    const [movies, setMovies] = useState<IMovie[]>([]);
    const [title, setTitle] :[string, React.Dispatch<SetStateAction<string>>] = useState("john wick");

    const fetchMovies = async (_title: string) => {
        const response :IMovie[] = await getMovies(_title);
        setMovies(response);
    }

    useEffect(() => {
        fetchMovies(title)
    }, [title])

    return (
        <>
            <Search setTitle={setTitle}/>
            <MovieList movies={movies} />
        </>
    );
}

export default MovieCatalog;