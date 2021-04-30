import { debug } from "console";
import { makeAutoObservable } from "mobx";
import React from "react";
import agent from "../api/agent";
import { Consultant } from "../models/consultant";
import { Review } from "../models/review";
import { v4 as uuid } from 'uuid';

export default class ConsultantStore{
    consultants:Consultant[]=[];
    selectedConsultant:Consultant | undefined = undefined;
    review: Review | undefined=undefined;

    constructor(){
        makeAutoObservable(this); 
    }
    
    loadConsultants= async ()=>{
       try{
            const consultants:Consultant[]= await agent.Consultants.list();
            consultants.forEach(consultant=>{
            this.consultants.push(consultant);
        })
       }catch(error){
           console.log(error);
       }
    }

    fetchReviewsForConsultant= async (consultant:Consultant)=>{
        const reviews:Review[]= await agent.Consultants.getListOfReviews(consultant);

        return reviews;
    }

    selectConsultant = (id:string)=>{
        this.selectedConsultant=this.consultants.find(c=>c.id===id);
    }

    postReviewForSelectedConsultant = async () =>{
        await agent.Consultants.postAReview(this.selectedConsultant,this.review);
    }

    setReview=(starReview:number | string | undefined,commentReview:string | number | undefined)=>{
        this.review={
            id:uuid(),
            starRating:starReview,
            comment:commentReview
        }
    }

    getReviewsForConsultant = async () =>{
        try{
            const reviews:Review[]= await agent.Consultants.getListOfReviews(this.selectedConsultant);
            return reviews;
        }catch(error){
            console.log(error);
        }
    }
}