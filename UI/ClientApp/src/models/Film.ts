import { Genre } from './Genre'
import { FilmPersonLink } from './FilmPersonLink'

export interface Film {
  filmId: number;
  filmTitle: string;
  releaseDate: Date;
  genreList: Genre[];
  filmPersonLinks: FilmPersonLink[];
}
