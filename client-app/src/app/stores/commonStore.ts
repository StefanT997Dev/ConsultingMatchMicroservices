import { makeAutoObservable } from "mobx";

export default class CommonStore{
    displayConsultantContact:boolean=false;

    constructor(){
        makeAutoObservable(this);
    }

    setDisplayConsultantContact=()=>{
        this.displayConsultantContact=!this.displayConsultantContact;
    }
}