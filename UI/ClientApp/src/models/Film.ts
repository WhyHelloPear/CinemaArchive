import { Genre } from './Genre'

export interface Film {
  filmId: number;
  filmTitle: string;
  releaseDate: Date;
  genreList: Genre[];
}
