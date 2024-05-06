import {useParams} from 'react-router-dom';
import {getMovie, IMovieData} from "./api/getMovie";
import {useEffect, useState} from "react";

import "./style.css"
import Header from "../../widgets/header/Header";
import Footer from "../../widgets/footer/Footer";
function MoviePage() {
    const [movie, setMovie] = useState<IMovieData>();
    const {id} = useParams();

    if(id === undefined) {
        return <span> Movie with this id not found! </span>
    }

    const fetchMovie = async (movieId: string) => {
        const movieData = await getMovie(id);
        setMovie(movieData);
    }

    // eslint-disable-next-line react-hooks/rules-of-hooks
    useEffect(() => {
        fetchMovie(id)
    }, [id])


    return (
        <>
            <Header/>
            <div className="movie-container">
                <img className="movie-poster" src={movie?.Poster} alt="Poster"/>
                <div className="movie-detail">
                    <span className="title">                {movie?.Title} </span>
                    <span className="year">     Year:       {movie?.Year}  </span>
                    <span className="type">     Type:       {movie?.Type}  </span>
                    <span className="long">     Duration:       {movie?.Runtime}  </span>
                    <span className="rated">    Rated:      {movie?.Rated}  </span>
                    <span className="director"> Director:   {movie?.Director}  </span>
                    <span className="genre">    Genre:      {movie?.Genre}  </span>
                    <span className="country">  Country:    {movie?.Country}  </span>
                    <span className="rating">   ImdbRate:   {movie?.imdbRating}  </span>
                    <span className="score">    Score:      {movie?.Metascore}  </span>
                </div>
            </div>
            <Footer/>
        </>
    );
}

export default MoviePage;