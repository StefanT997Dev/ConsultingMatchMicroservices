import { observer } from "mobx-react-lite";
import React, { useEffect, useState } from "react";
import { Form as FinalForm } from "react-final-form";
import { Header, Form, Container, Button } from "semantic-ui-react";
import { useStore } from "../../stores/store";
import "./SkillsForm.scss";

export default observer(function SkillsForm() {
  const { skillStore, categoryStore } = useStore();

  useEffect(() => {
    skillStore.getSkillsForSelectedCategory(
      categoryStore.getSelectedCategoryId()
    );
  }, []);
  
  return (
    <Container textAlign="center" className="skills-form">
      <div className="skills-form__form">
        <FinalForm
          onSubmit={() => console.log("sdsdsd")}
          render={({ handleSubmit, valid, values, submitting }) => (
            <Form onSubmit={() => console.log("ssd")}>
              <Header as="h1">
                Select skills you possess for "Category Name"
              </Header>
              {skillStore.skillsForSelectedCategory&&skillStore.skillsForSelectedCategory?.map((skill) => (
                  <Button toggle>{skill.name}</Button>
              ))}
            </Form>
          )}
        />
      </div>
    </Container>
  );
});
