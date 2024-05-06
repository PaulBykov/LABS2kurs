import {IMovie} from "../../MovieCard/MovieCard";
import {MovieType} from "../../../../feateures/filter/Filter";

const API_KEY = process.env.REACT_APP_API_KEY;
const API_URL = process.env.REACT_APP_API_URL;

interface IResponse {
    Search: IMovie[];
}

export async function getMovies(title: string, type: MovieType): Promise<IMovie[]> {

    let queryString = `${API_URL}apikey=${API_KEY}&s=${title}`;

    if(type !== "any"){
        queryString += `&type=${type}`;
    }

    const data :IMovie[] =
        await fetch(queryString)
            .then(response => response.json())
            .then((result: IResponse) => result.Search)

    return data;
}
