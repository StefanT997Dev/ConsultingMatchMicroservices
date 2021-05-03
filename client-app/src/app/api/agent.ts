import axios, { AxiosResponse } from 'axios';
import { Category } from '../models/category';
import { Consultant } from '../models/consultant';
import { Message } from '../models/message';
import { Review } from '../models/review';
import { UserFormValues } from '../models/user';

axios.defaults.baseURL='http://localhost:5000';

const responseBody=(response:AxiosResponse) => response.data.value;

const requests = {
    get:(url:string) => axios.get(url).then(responseBody),
    post:(url:string,body:{}) => axios.post(url,body).then(responseBody),
    put:(url:string,body:{}) => axios.put(url,body).then(responseBody),
    del:(url:string) => axios.delete(url).then(responseBody)
}

const Consultants={
    list:()=>requests.get('/consultants'),
    postAReview:(selectedConsultant:Consultant | undefined,review:Review | undefined)=>
        requests.post("/consultants/"+selectedConsultant?.id+"/reviews",{starRating:review?.starRating,comment:review?.comment}),
    getListOfReviews:(currentConsultant:Consultant|undefined) => requests.get("/consultants/"+currentConsultant?.id+"/reviews"),
    listForSelectedCategory:(selectedCategory:Category | undefined | null)=>requests.get("/categories/"+selectedCategory?.id+"/consultants")
}

const Categories={
    list:()=>requests.get('/categories')
}

const Messages={
    send:(selectedConsultant:Consultant | undefined,message:Message|undefined) => requests.post("/message/"+selectedConsultant?.id,{id:message?.id,content:message?.content})
}

const Account={
    current: ()=>requests.get('/account'),
    login: (user:UserFormValues) => requests.post('/account/login',user),
    register:(user:UserFormValues)=>requests.post('/account/register',user)
}

const agent={
    Consultants,
    Categories,
    Messages,
    Account
}

export default agent;