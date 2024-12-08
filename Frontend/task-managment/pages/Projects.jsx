import React, { useState } from "react";
import { Box, Container, Stack, Text, Heading, Button } from "@chakra-ui/react";

// Пример данных
const tasks = [
  { id: 1, title: "Задача 1", description: "Описание задачи 1" },
  { id: 2, title: "Задача 2", description: "Описание задачи 2" },
  { id: 3, title: "Задача 3", description: "Описание задачи 3" },
];

const Projects = () => {
  const [expandedTaskId, setExpandedTaskId] = useState(null);

  const toggleTask = (taskId) => {
    setExpandedTaskId(expandedTaskId === taskId ? null : taskId);
  };

  return (
    <Container maxW="lg" mt="8">
      <Heading
        size="lg"
        mb="6"
        textAlign="center"
        bgGradient="linear(to-r, purple.500, blue.500)"
        bgClip="text"
      >
        Список задач
      </Heading>
      <Stack spacing="6">
        {tasks.map((task) => (
          <Box
            key={task.id}
            p="6"
            borderRadius="lg"
            boxShadow="lg"
            bg="white"
            _hover={{ bg: "gray.50", transform: "scale(1.02)" }}
            transition="all 0.2s"
          >
            <Heading size="md" mb="3" color="purple.600">
              {task.title}
            </Heading>
            <Button
              size="sm"
              onClick={() => toggleTask(task.id)}
              bg="purple.500"
              color="white"
              _hover={{ bg: "purple.600" }}
              _active={{ bg: "purple.700" }}
            >
              {expandedTaskId === task.id ? "Скрыть" : "Развернуть"}
            </Button>
            {expandedTaskId === task.id && (
              <Text mt="4" color="gray.700">
                {task.description}
              </Text>
            )}
          </Box>
        ))}
      </Stack>
    </Container>
  );
};

export default Projects;
