import {
    Box,
    Container,
    Stack,
    Input,
    Button,
    Text,
    Link,
    Heading,
  } from "@chakra-ui/react";
  
  const Registration = () => {
    return (
      <Container
        maxW="md"
        p="6"
        boxShadow="xl"
        borderRadius="lg"
        bg="grey.500"
        mt="8"
      >
        <Heading textAlign="center" size="xl" color="white" mb="6">
          Регистрация
        </Heading>
        <Box as="form">
          <Stack spacing="4">
            <Input  placeholder="Логин" size="lg" focusBorderColor="purple.400" />
            <Input  placeholder="E-mail" size="lg" focusBorderColor="purple.400"/>
            <Input
              placeholder="Пароль"
              type="password"
              size="lg"
              focusBorderColor="purple.400"
            />
            <Button size="lg" bg="purple.500" color="white" _hover={{ bg: "purple.600" }}>
              Зарегистрироваться
            </Button>
  
            {/* Разделитель */}
            <Box
              height="1px"
              bg="gray.200"
              my="4"
              borderRadius="full"
              w="full"
            />
  
            {/* Дополнительный текст */}
            <Text textAlign="center" fontSize="sm" color="white">
              Уже есть аккаунт?{" "}
              <Link color="purple.500" href="/login">
                Войти
              </Link>
            </Text>
          </Stack>
        </Box>
      </Container>
    );
  };
  
  export default Registration;
  