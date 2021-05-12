import { makeAutoObservable } from "mobx";

export default class CommonStore{
    displayConsultantContact:boolean=false;
    token:string|null=null;
    appLoaded=false;

    constructor(){
        makeAutoObservable(this);
    }

    setDisplayConsultantContact=()=>{
        this.displayConsultantContact=!this.displayConsultantContact;
    }

    setToken=(token:string|null)=>{
        if(token) window.localStorage.setItem('jwt',token);
        this.token=token;
    }

    setAppLoaded=()=>{
        this.appLoaded=true;
    }
}