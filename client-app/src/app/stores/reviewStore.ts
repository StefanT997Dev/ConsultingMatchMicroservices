import { makeAutoObservable } from "mobx";
import { Review } from "../models/review";
import { v4 as uuid } from 'uuid';

export default class ReviewStore{
    review: Review | undefined=undefined;

    constructor(){
        makeAutoObservable(this);
    }

    setReview=(starReview:number | string | undefined,commentReview:string | number | undefined)=>{
        this.review={
            id:uuid(),
            starRating:starReview,
            comment:commentReview
        }
    }
}