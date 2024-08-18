# Use an official Node.js runtime as a parent image
FROM node:16 AS build
WORKDIR /app

# Copy package.json and install dependencies
COPY package*.json ./
RUN npm install

# Copy the rest of the application code
COPY . ./

# Build the application
RUN npm run build

# Use an Nginx image to serve the frontend
FROM nginx:alpine
COPY --from=build /app/build /usr/share/nginx/html

# Expose port 80 to the outside world
EXPOSE 80

# Start Nginx when the container launches
CMD ["nginx", "-g", "daemon off;"]
