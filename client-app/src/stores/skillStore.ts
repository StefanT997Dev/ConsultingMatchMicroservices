import { makeAutoObservable, runInAction } from "mobx";
import agent from "../api/agent";
import { Skill } from "../models/skill";

export default class SkillStore{    
    skillsForSelectedCategory:Skill[]=[];

    constructor(){
        makeAutoObservable(this);
    }

    getSkillsForSelectedCategory=async(categoryId:string | undefined)=>{
        var skills = await agent.Skills.list(categoryId);
        skills.forEach((skill:Skill) => {
            runInAction(()=>this.skillsForSelectedCategory.push(skill));
        });
    }
}