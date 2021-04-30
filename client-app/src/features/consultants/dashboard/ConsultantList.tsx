import { constants } from "buffer";
import { debug } from "console";
import { observer } from "mobx-react-lite";
import React from "react";
import { Item, Segment, Button, Label, Rating } from "semantic-ui-react";
import { useStore } from "../../../app/stores/store";

export default observer(function ConsultantList(){
    const {consultantStore}=useStore();

    debugger
    return(
        <Segment>
            <Item.Group divided>
                {consultantStore.consultants.map(consultant=>(
                    <Item key={consultant.id}>
                        <Item.Content>
                            <Item.Header as='a'>
                                {consultant.displayName}
                            </Item.Header>
                            <Item.Meta>
                                {consultant.bio}
                            </Item.Meta>
                            <Item.Description>
                                <Rating icon='star' defaultRating={consultant.averageStarReview} maxRating={5} disabled size='huge'/>
                                (Number of reviews: {consultant.numberOfReviews})
                            </Item.Description>
                            <Item.Extra>
                                <Button onClick={()=>consultantStore.selectConsultant(consultant.id)} floated ='right' content='View' color='blue'/>
                                <Label basic content={consultant.reviews[0].comment} />
                            </Item.Extra>
                        </Item.Content>
                    </Item>
                ))}
            </Item.Group>
        </Segment>
    )
})