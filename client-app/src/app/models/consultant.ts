import { Review } from "./review";

export interface Consultant{
    id:string;
    displayName:string;
    image: string;
    averageStarReview: number;
    numberOfReviews:number;
    bio: string;
    reviews:Review[];
}