import React from "react";
import { Button, Item, Progress, Segment } from "semantic-ui-react";
import { useStore } from "../../app/stores/store";

export default function ProfileHeader() {
  const { consultantStore } = useStore();

  return (
    <div>
      <Segment>
        <Item.Group>
          <Item>
            <Item.Image
              src={require("../../images/homersimpson.0.0.jpg")}
              size="small"
            />
            <Item.Content style={{ marginTop: "3em" }}>
              <Item.Group>
                <Item>
                  <Item.Header>
                    {consultantStore.selectedConsultant?.displayName}
                  </Item.Header>
                  <Item.Content style={{marginLeft:'10em',fontSize:'xx-large',fontStyle:'bold'}}>125 Followers</Item.Content>
                  <Item.Content style={{fontSize:'xx-large',fontStyle:'bold'}}>14 Following</Item.Content>
                </Item>
              </Item.Group>
              <Item.Description>
                {consultantStore.selectedConsultant?.bio}
              </Item.Description>
              <Progress percent={50} style={{ width: "17em" }} success>
                {consultantStore.selectedConsultant?.categories[0]} Level: {4}
              </Progress>
              <Button.Group widths="2">
                <Button floated="right" positive>
                  Hire
                </Button>
                <Button floated="right" primary>
                  Follow
                </Button>
              </Button.Group>
            </Item.Content>
          </Item>
        </Item.Group>
      </Segment>
    </div>
  );
}
