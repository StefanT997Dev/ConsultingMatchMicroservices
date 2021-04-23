import { Item, Segment, Button, Label } from "semantic-ui-react";
import ConsultantDashboard from "./ConsultantDashboard";

export default function ConsultantList(){
    return(
        <Segment>
            <Item.Group divided>
                {/* {consultants.map(consultant=>(
                    <Item key={consultant.Id}>
                        <Item.Content>
                            <Item.Header as='a'>
                                {consultant.title}
                            </Item.Header>
                            <Item.Meta>
                                {consultant.date}
                            </Item.Meta>
                            <Item.Description>
                                <div>{consultant.descrption}</div>
                                <div>{consultant.city}, {consultant.venue}</div>
                            </Item.Description>
                            <Item.Extra>
                                <Button floated ='right' content='View' color='blue'/>
                                <Label basic content={consultant.category} />
                            </Item.Extra>
                        </Item.Content>
                    </Item>
                ))} */}
            </Item.Group>
        </Segment>
    )
}